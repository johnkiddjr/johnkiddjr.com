using Infrastructure.Contexts;
using Infrastructure.Models;
using MainSite.Options;
using MainSite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using IO = System.IO;
using System.IO.Compression;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using MainSite.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Models.Identity;
using System.Security.Claims;
using Markdig.Renderers.Html;
using MainSite.Services;

namespace MainSite.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly MainSiteContext _context;
        private readonly CDNOptions _cdnOptions;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMarkdownService _markdownService;

        public ArticleController(ILogger<ArticleController> logger, MainSiteContext context, IOptions<CDNOptions> options, UserManager<ApplicationUser> userManager, IMarkdownService markdownService)
        { 
            _logger = logger;
            _context = context;
            _cdnOptions = options.Value;
            _userManager = userManager;
            _markdownService = markdownService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await GenerateArticleIndexViewModel();

            return View(viewModel);
        }

        [Route("{controller}/View/{articleSlug}")]
        public async Task<IActionResult> ViewArticle(string articleSlug)
        {
            var viewModel = await GenerateArticleViewModel(articleSlug);

            return View(viewModel);
        }

        [Authorize]
        [Route("{controller}/Upload")]
        public IActionResult UploadArticle()
        {
            return View(new UploadArticleViewModel());
        }

        [HttpPost]
        [Authorize]
        [Route("{controller}/UploadArticle")]
        [RequestSizeLimit(209715200)]
        public async Task<IActionResult> UploadNewArticle([FromForm] UploadArticleViewModel viewModel)
        {
            if (!viewModel.Content.FileName.EndsWith(".zip", true, null))
            {
                ModelState.AddModelError("", "File must be a zip file containing 1 Markdown file and accompanying media...");
            }

            if (viewModel.Content.Length <= 0)
            {
                ModelState.AddModelError("", "File uploaded has no data!");
            }

            if (ModelState.ErrorCount > 0)
            {
                return View("UploadArticle", viewModel);
            }

            //get the bioid from the logged in user
            var userGuid = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault();
            var user = await _userManager.FindByIdAsync(userGuid);
            var bioId = user.BioId;

            //create a variable to hold this value for table insertion later
            string articleFilename = string.Empty;
            string articleFullLocalPath = string.Empty;

            Dictionary<string, string> filenameChanges = new Dictionary<string, string>();

            //read zip file into byte array
            using var fStream = viewModel.Content.OpenReadStream();
            using var archive = new ZipArchive(fStream);

            if (archive.Entries.Count(x => x.Name.EndsWith(".md")) != 1)
            {
                ModelState.AddModelError("", "Zip file must contain exactly 1 Markdown file!");
            }

            foreach (var entry in archive.Entries)
            {
                using var sr = new StreamReader(entry.Open());

                if (IsFileMarkdownFile(entry.Name))
                {
                    articleFilename = GenerateRandomFilename(entry.Name);
                    articleFullLocalPath = $"{_cdnOptions.LocalStoragePath}{_cdnOptions.ArticlesStub}/{articleFilename}";
                    using var fileStream = IO.File.Create(articleFullLocalPath);
                    entry.Open().CopyTo(fileStream);
                    fileStream.Close();
                }
                else if (IsFileImageFile(entry.Name))
                {
                    var newImageName = GenerateRandomFilename(entry.Name);
                    filenameChanges.Add(entry.Name, newImageName);

                    using var fileStream = IO.File.Create($"{_cdnOptions.LocalStoragePath}{_cdnOptions.ImagesStub}/{newImageName}");
                    entry.Open().CopyTo(fileStream);
                    fileStream.Close();
                }
                else
                {
                    var newOtherName = GenerateRandomFilename(entry.Name);
                    filenameChanges.Add(entry.Name, newOtherName);

                    using var fileStream = IO.File.Create($"{_cdnOptions.LocalStoragePath} {_cdnOptions.OtherStub}/{newOtherName}");
                    entry.Open().CopyTo(fileStream);
                    fileStream.Close();
                }
            }

            //created a scoped section so the stream reader and writer get disposed before the end of the function
            {
                using var sr = new StreamReader(articleFullLocalPath);
                string rawMarkdownContents = sr.ReadToEnd();
                sr.Close();

                //reopen the markdown file and do a simple text replace for each filename we changed
                foreach (var changedFilename in filenameChanges)
                {
                    rawMarkdownContents = rawMarkdownContents.Replace(changedFilename.Key, changedFilename.Value);
                }

                using var sw = new StreamWriter(articleFullLocalPath, false);
                sw.Write(rawMarkdownContents);
                sw.Flush();
                sw.Close();
            }

            //process tags
            var tags = viewModel.Tags.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim());
            var tagsToAdd = new List<Guid>();

            foreach (var tag in tags)
            {
                //lookup to see if the tag already exists...
                var tagToProcess = _context.Tags.AsEnumerable().Where(t => t.Name.ToLowerInvariant() == tag.ToLowerInvariant()).FirstOrDefault();

                if (tagToProcess == null)
                {
                    tagToProcess = new Tag() { Name = tag };
                    await _context.Tags.AddAsync(tagToProcess);
                    await _context.SaveChangesAsync();
                }

                tagsToAdd.Add(tagToProcess.TagId);
            }

            var article = new Article()
            {
                AuthorId = bioId,
                AvailableDate = viewModel.AvailableDate,
                UploadDate = DateTime.Now,
                FileName = articleFilename,
                Slug = viewModel.Slug,
                Title = viewModel.Title,
                PreviewText = viewModel.PreviewText,
                Visible = viewModel.Visible
            };

            await _context.Articles.AddAsync(article);

            if (await _context.SaveChangesAsync() < 1)
            {
                ModelState.AddModelError("", "Unable to save to database...");
            }

            if (ModelState.ErrorCount > 0)
            {
                return View("UploadArticle", viewModel);
            }

            //add tags to relationship table
            foreach (var tag in tagsToAdd)
            {
                await _context.ArticleTagRelations.AddAsync(new ArticleTag() { ArticleId = article.ArticleId, TagId = tag });
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private async Task<ArticleIndexViewModel> GenerateArticleIndexViewModel()
        {
            var articles = (from article in _context.Articles where article.Visible select article).OrderByDescending(x => x.AvailableDate).ToList();

            var viewModel = new ArticleIndexViewModel();
            viewModel.Articles = new List<ArticleViewModel>();

            foreach (var dbArticle in articles)
            {
                viewModel.Articles.Add(await ConvertDBArticleToArticleViewModel(dbArticle));
            }

            return viewModel;
        }

        private async Task<ArticleViewModel> GenerateArticleViewModel(string slug)
        {
            var article = (from dbArticle in _context.Articles where dbArticle.Slug == slug && dbArticle.Visible select dbArticle).FirstOrDefault();

            var viewModel = await ConvertDBArticleToArticleViewModel(article);

            return viewModel;
        }

        private async Task<ArticleViewModel> ConvertDBArticleToArticleViewModel(Article article)
        {
            if (article == null)
            {
                return null;
            }

            var articleViewModel = new ArticleViewModel();

            var authorName = (from bio in _context.Bios select bio)
                .AsEnumerable()
                .Where(x => x.BioId == article.AuthorId)
                .Select(x => x.Name)
                .FirstOrDefault("N/A");

            var tags = (from relations in _context.ArticleTagRelations
                        where relations.ArticleId == article.ArticleId
                        join t in _context.Tags on relations.TagId equals t.TagId
                        select t.Name).ToList();

            var tagList = new List<TagViewModel>();

            foreach (var tag in tags)
            {
                tagList.Add(new TagViewModel() { Name = tag });
            }

            articleViewModel.Author = authorName;
            articleViewModel.Slug = article.Slug;
            articleViewModel.PreviewText = article.PreviewText;
            articleViewModel.Title = article.Title;
            articleViewModel.PublishDate = article.AvailableDate;
            articleViewModel.Visible = article.Visible;
            articleViewModel.Tags = tagList;
            articleViewModel.HtmlText = await GetMarkdownFileContents(article.FileName);

            return articleViewModel;
        }

        private async Task<string> GetMarkdownFileContents(string markdownFileName) =>
            await _markdownService.GetHtmlFromMarkdownUrl($"{_cdnOptions.ArticlesStub}/{markdownFileName}", md =>
            {
                foreach (var mdItem in md)
                {
                    if (mdItem is ParagraphBlock)
                    {
                        foreach (var inlineItem in (mdItem as ParagraphBlock).Inline)
                        {
                            if (inlineItem is LinkInline && (inlineItem as LinkInline).IsImage)
                            {
                                var imageLinkInline = inlineItem as LinkInline;
                                imageLinkInline.Url = imageLinkInline.Url.ToLowerInvariant().StartsWith("http") ? imageLinkInline.Url : ContentHelper.GetUrlForResource(ContentType.images, imageLinkInline.Url);
                                imageLinkInline.SetAttributes(new HtmlAttributes() { Classes = new List<string>() { "article-image" } });
                            }
                        }
                    }
                }
            });

        private bool IsFileMarkdownFile(string fileName) =>
            fileName.EndsWith(".md");

        private bool IsFileImageFile(string fileName)
        {
            if (fileName.EndsWith(".jpg"))
            {
                return true;
            }

            if (fileName.EndsWith(".jpeg"))
            {
                return true;
            }

            if (fileName.EndsWith(".png"))
            {
                return true;
            }

            if (fileName.EndsWith(".gif"))
            {
                return true;
            }

            return false;
        }

        private string GenerateRandomFilename(string originalFileName)
        {
            // find the file extension
            int lastPeriod = originalFileName.LastIndexOf(".");
            var extension = originalFileName.Substring(lastPeriod + 1);

            return $"{Guid.NewGuid().ToString("N")}.{extension}";
        }
    }
}
