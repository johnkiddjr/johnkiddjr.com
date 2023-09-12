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
using MainSite.Services;

namespace MainSite.Controllers
{
    [Route("{controller}")]
    public class ProjectController : Controller
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectService _projectService;
        private readonly MainSiteContext _context;
        private readonly CDNOptions _cdnOptions;

        public ProjectController(ILogger<ProjectController> logger, MainSiteContext context, IOptions<CDNOptions> cdnOptions, IProjectService projectService)
        {
            _logger = logger;
            _context = context;
            _cdnOptions = cdnOptions.Value;
            _projectService = projectService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("DeleteProject")]
        [Authorize]
        public IActionResult DeleteProject()
        {
            return View(new DeleteProjectViewModel());
        }

        [HttpPost("DeleteProject")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> PostDeleteProject(DeleteProjectViewModel viewModel)
        {
            // this is just a validation step to trigger an error before leroy jenkinsing the database
            var project = await _projectService.GetProjectBySlug(viewModel.Slug);

            if (project == null)
            {
                ModelState.AddModelError("", $"No project found with the slug: {viewModel.Slug}");
                return View("DeleteProject", viewModel);
            }

            if (!await _projectService.DeleteProjectBySlug(viewModel.Slug))
            {
                ModelState.AddModelError("", $"Unable to delete project: {viewModel.Slug}");
                return View("DeleteProject", viewModel);
            }

            return RedirectToAction("Index", "Admin", new { message = $"Project {project.Name} Deleted!" });
        }

        [HttpGet("AddProject")]
        [Authorize]
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
        [Authorize]
        public IActionResult PostAddProject([FromForm] ProjectViewModel viewModel)
        {
            //check all required fields...
            if (string.IsNullOrWhiteSpace(viewModel.Name) ||
                string.IsNullOrWhiteSpace(viewModel.ShortDescription) ||
                string.IsNullOrWhiteSpace(viewModel.Description) ||
                string.IsNullOrWhiteSpace(viewModel.Slug) ||
                string.IsNullOrWhiteSpace(viewModel.Platform))
            {
                ModelState.AddModelError("", "One of the required fields is missing: Name, Platform, Short Description, Description, Slug");
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

            var platforms = viewModel.Platform.Split(',');

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

            // add the platforms
            foreach (var platform in platforms)
            {
                //find the platform
                var foundPlatform = (from plat in _context.Platforms
                                     where plat.Name == platform
                                     select plat.PlatformId).FirstOrDefault();

                if (foundPlatform == Guid.Empty)
                {
                    //Can't find the platform...
                    ModelState.AddModelError("", "Database Error: Unable to add platform");
                    return View(viewModel);
                }

                _context.ProjectPlatforms.Add(new ProjectPlatform
                {
                    PlatformId = foundPlatform,
                    ProjectId = project.ProjectId
                });

                _context.SaveChanges();
            }

            //upload images to CDN and save to database
            if (viewModel.Images != null)
            {
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
            }

            //save extra links to database
            if (viewModel.AdditionalLinks != null)
            {
                foreach (var link in viewModel.AdditionalLinks)
                {
                    _context.ProjectLinks.Add(new ProjectLink
                    {
                        ProjectId = project.ProjectId,
                        Text = link.LinkText,
                        Url = link.LinkUrl
                    });
                }
            }

            if ((viewModel.AdditionalLinks.Count > 0 || viewModel.Images.Count > 0) && _context.SaveChanges() < 1)
            {
                ModelState.AddModelError("", "Failed to save images or additional links!");
                return View(viewModel);
            }

            return RedirectToAction("Index", "Admin", new { message = "Project Added!" });
        }

        [HttpGet("AddPlatform")]
        public IActionResult AddPlatform()
        {
            var viewModel = new PlatformViewModel();

            return View(viewModel);
        }

        [HttpPost("AddPlatform")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult PostAddPlatform(PlatformViewModel viewModel)
        {
            // validate
            if (string.IsNullOrWhiteSpace(viewModel.PlatformName))
            {
                ModelState.AddModelError("", "Required field is missing: Name");
                return View(viewModel);
            }

            // save to database
            _context.Platforms.Add(new Platform { Name = viewModel.PlatformName });
            if (_context.SaveChanges() == 0)
            {
                ModelState.AddModelError("", "Database Error: Unable to save");
                return View(viewModel);
            }

            return RedirectToAction("Index", "Admin", new { message = "Platform Added!" });
        }
    }
}