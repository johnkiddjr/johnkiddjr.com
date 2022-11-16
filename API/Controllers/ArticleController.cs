using API.Options;
using API.ViewModels;
using Infrastructure.Contexts;
using Infrastructure.Models;
using Markdig;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestSharp;
using IO = System.IO;
using System.IO.Compression;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly MainSiteContext context;
        private readonly CDNOptions cdnOptions;

        public ArticleController(MainSiteContext context, IOptions<CDNOptions> options)
        {
            this.context = context;
            this.cdnOptions = options.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var viewModel = await GenerateArticleIndexViewModel();

            return Ok(viewModel);
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> Get(string slug)
        {
            var viewModel = await GenerateArticleViewModel(slug);

            return Ok(viewModel);
        }

        [HttpPut]
        [RequestSizeLimit(209715200)]
        public async Task<IActionResult> UploadNewArticle([FromForm] UploadArticleViewModel viewModel)
        {
            if (!viewModel.Content.FileName.EndsWith(".zip", true, null))
            {
                return BadRequest("File must be a zip file containing 1 Markdown file and accompanying media...");
            }

            if (viewModel.Content.Length <= 0)
            {
                return BadRequest("File uploaded has no data!");
            }

            //generate a filename with a guid or something
            var filename = GenerateRandomFilename("md");

            //read zip file into byte array
            using var fStream = viewModel.Content.OpenReadStream();
            using var archive = new ZipArchive(fStream);

            if (archive.Entries.Count(x => x.Name.EndsWith(".md")) != 1)
            {
                return BadRequest("Zip file must contain exactly 1 Markdown file!");
            }

            foreach (var entry in archive.Entries)
            {
                using var sr = new StreamReader(entry.Open());

                if (IsFileMarkdownFile(entry.Name))
                {
                    using var fileStream = IO.File.Create($"{cdnOptions.LocalStoragePath}{cdnOptions.ArticlesStub}/{filename}");
                    entry.Open().CopyTo(fileStream);
                }
                else if (IsFileImageFile(entry.Name))
                {
                    using var fileStream = IO.File.Create($"{cdnOptions.LocalStoragePath}{cdnOptions.ImagesStub}/{entry.Name}");
                    entry.Open().CopyTo(fileStream);
                }
                else
                {
                    using var fileStream = IO.File.Create($"{cdnOptions.LocalStoragePath}{cdnOptions.OtherStub}/{entry.Name}");
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

            context.Articles.Add(article);
            context.SaveChanges();

            return Ok();
        }

        private async Task<ArticleIndexViewModel> GenerateArticleIndexViewModel()
        {
            var articles = (from article in context.Articles where article.Visible select article).ToList();

            var viewModel = new ArticleIndexViewModel();
            viewModel.articles = new List<ArticleViewModel>();

            foreach (var dbArticle in articles)
            {
                viewModel.articles.Add(await ConvertDBArticleToArticleViewModel(dbArticle));
            }

            return viewModel;
        }

        private async Task<ArticleViewModel> GenerateArticleViewModel(string slug)
        {
            var article = (from dbArticle in context.Articles where dbArticle.Slug == slug && dbArticle.Visible select dbArticle).FirstOrDefault();

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

            var authorName = (from bio in context.Bios select bio)
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
            var client = new RestClient(cdnOptions.BaseUrl);
            var request = new RestRequest($"{cdnOptions.ArticlesStub}/{markdownFileName}", Method.Get);
            var response = await client.GetAsync(request);

            if (response == null || response.Content == null)
            {
                return string.Empty;
            }

            return Markdown.ToHtml(response.Content);
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
