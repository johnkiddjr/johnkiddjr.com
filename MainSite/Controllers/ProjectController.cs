using Infrastructure.Contexts;
using IO = System.IO;
using MainSite.Extensions;
using MainSite.Options;
using MainSite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Infrastructure.Models;
using Infrastructure.Enumerations;

namespace MainSite.Controllers
{
    [Route("{controller}")]
    public class ProjectController : Controller
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly MainSiteContext _context;
        private readonly CDNOptions _cdnOptions;

        public ProjectController(ILogger<ProjectController> logger, MainSiteContext context, IOptions<CDNOptions> cdnOptions)
        {
            _logger = logger;
            _context = context;
            _cdnOptions = cdnOptions.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("AddProject")]
        public IActionResult AddProject()
        {
            var viewModel = new ProjectViewModel();
            viewModel.AdditionalLinks = new List<ProjectLinkViewModel>();
            viewModel.Images = new List<ProjectImageViewModel>();

            return View(viewModel);
        }

        [HttpPost("AddProject")]
        [RequestSizeLimit(209715200)]
        [ValidateAntiForgeryToken]
        public IActionResult PostAddProject([FromForm] ProjectViewModel viewModel)
        {
            //check all required fields...
            if (string.IsNullOrWhiteSpace(viewModel.Name) ||
                string.IsNullOrWhiteSpace(viewModel.ShortDescription) ||
                string.IsNullOrWhiteSpace(viewModel.Description) ||
                string.IsNullOrWhiteSpace(viewModel.Slug))
            {
                ModelState.AddModelError("", "One of the required fields is missing: Name, Short Description, Description, Slug");
                return View(viewModel);
            }

            //slug has to be unique!
            var matchingSlugs = (from slugs in _context.Projects
                                 where slugs.ProjectSlug == viewModel.Slug
                                 select slugs).ToList();

            if (matchingSlugs != null && matchingSlugs.Any())
            {
                ModelState.AddModelError("", $"Slug must be unique! Slug {viewModel.Slug} was found in the database!");
                return View(viewModel);
            }

            //save to database
            var project = new Project
            {
                Description = viewModel.Description,
                ShortDescription = viewModel.ShortDescription,
                DownloadUrl = viewModel.DownloadUrl,
                LanguageUsed = viewModel.LanguageUsed,
                LibrariesUsed = viewModel.LibrariesUsed,
                Name = viewModel.Name,
                NetVersion = viewModel.NetVersion,
                ProjectSlug = viewModel.Slug,
                RepositoryUrl = viewModel.RepositoryUrl,
                ProjectType = (ProjectType)Enum.Parse(typeof(ProjectType), viewModel.ProjectType),
                RepositoryType = (RepositoryType)Enum.Parse(typeof(RepositoryType), viewModel.RepositoryType),
                DateAdded = DateTime.Now
            };

            _context.Projects.Add(project);

            if (_context.SaveChanges() < 1)
            {
                ModelState.AddModelError("", "Failed to save project to database!");
                return View(viewModel);
            }

            //upload images to CDN and save to database
            foreach (var image in viewModel.Images)
            {
                //ignore anything that is not an image
                if (!image.ImageFile.IsImageFile())
                {
                    continue;
                }

                var newImageName = image.ImageFile.GenerateRandomFilename();
                image.ImageUrl = newImageName;

                using var fileStream = IO.File.Create($"{_cdnOptions.LocalStoragePath}{_cdnOptions.ImagesStub}/{newImageName}");
                image.ImageFile.OpenReadStream().CopyTo(fileStream);
                fileStream.Close();

                _context.ProjectImages.Add(new ProjectImage
                {
                    AltText = image.AltText,
                    ProjectId = project.ProjectId,
                    Url = image.ImageUrl
                });
            }

            //save extra links to database
            foreach (var link in viewModel.AdditionalLinks)
            {
                _context.ProjectLinks.Add(new ProjectLink
                {
                    ProjectId = project.ProjectId,
                    Text = link.LinkText,
                    Url = link.LinkUrl
                });
            }

            if ((viewModel.AdditionalLinks.Count > 0 || viewModel.Images.Count > 0) && _context.SaveChanges() < 1)
            {
                ModelState.AddModelError("", "Failed to save images or additional links!");
                return View(viewModel);
            }

            return RedirectToAction("Index", "Admin", new { message = "Project Added!" });
        }
    }
}