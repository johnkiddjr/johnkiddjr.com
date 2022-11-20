using Infrastructure.Contexts;
using Infrastructure.Models;
using MainSite.Options;
using MainSite.ViewModels;
using Markdig;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestSharp;
using IO = System.IO;
using System.IO.Compression;
using Markdig.Renderers;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using MainSite.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Models.Identity;
using System.Security.Claims;
using Markdig.Renderers.Html;

namespace MainSite.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly MainSiteContext _context;
        private readonly CDNOptions _cdnOptions;
        private readonly UserManager<ApplicationUser> _userManager;

        public ArticleController(ILogger<ArticleController> logger, MainSiteContext context, IOptions<CDNOptions> options, UserManager<ApplicationUser> userManager)
        { 
            _logger = logger;
            _context = context;
            _cdnOptions = options.Value;
            _userManager = userManager;
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

            //generate a filename with a guid or something
            var filename = GenerateRandomFilename("md");

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
                    using var fileStream = IO.File.Create($"{_cdnOptions.LocalStoragePath}{_cdnOptions.ArticlesStub}/{filename}");
                    entry.Open().CopyTo(fileStream);
                }
                else if (IsFileImageFile(entry.Name))
                {
                    using var fileStream = IO.File.Create($"{_cdnOptions.LocalStoragePath}{_cdnOptions.ImagesStub}/{entry.Name}");
                    entry.Open().CopyTo(fileStream);
                }
                else
                {
                    using var fileStream = IO.File.Create($"{_cdnOptions.LocalStoragePath} {_cdnOptions.OtherStub}/{entry.Name}");
                    entry.Open().CopyTo(fileStream);
                }
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
                FileName = filename,
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

        private async Task<string> GetMarkdownFileContents(string markdownFileName)
        {
            var client = new RestClient(_cdnOptions.BaseUrl);
            var request = new RestRequest($"{_cdnOptions.ArticlesStub}/{markdownFileName}", Method.Get);
            var response = await client.GetAsync(request);

            if (response == null || response.Content == null)
            {
                return string.Empty;
            }

            var md = Markdown.Parse(response.Content);
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
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();

            return md.ToHtml(pipeline);
        }

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

        private string GenerateRandomFilename(string fileExt) =>
            $"{Guid.NewGuid().ToString("N")}.{fileExt}";
    }
}
