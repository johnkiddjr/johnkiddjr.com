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

namespace MainSite.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly MainSiteContext _context;
        private readonly CDNOptions _cdnOptions;

        public ArticleController(ILogger<ArticleController> logger, MainSiteContext context, IOptions<CDNOptions> options)
        { 
            _logger = logger;
            _context = context;
            _cdnOptions = options.Value;
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

            var article = new Article()
            {
                AuthorId = viewModel.AuthorId,
                AvailableDate = viewModel.AvailableDate,
                UploadDate = DateTime.Now,
                FileName = filename,
                Slug = viewModel.Slug,
                Title = viewModel.Title,
                PreviewText = viewModel.PreviewText,
                Visible = viewModel.Visible
            };

            await _context.Articles.AddAsync(article);
            if (_context.SaveChanges() < 1)
            {
                ModelState.AddModelError("", "Unable to save to database...");
            }

            if (ModelState.ErrorCount > 0)
            {
                return View("UploadArticle", viewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<ArticleIndexViewModel> GenerateArticleIndexViewModel()
        {
            var articles = (from article in _context.Articles where article.Visible select article).ToList();

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

            articleViewModel.Author = authorName;
            articleViewModel.Slug = article.Slug;
            articleViewModel.PreviewText = article.PreviewText;
            articleViewModel.Title = article.Title;
            articleViewModel.PublishDate = article.AvailableDate;
            articleViewModel.Visible = article.Visible;
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
