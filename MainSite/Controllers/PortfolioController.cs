using Infrastructure.Contexts;
using MainSite.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MainSite.Controllers
{
    [Route("[controller]")]
    public class PortfolioController : Controller
    {
        private readonly ILogger<PortfolioController> _logger;
        private readonly MainSiteContext _context;

        public PortfolioController(ILogger<PortfolioController> logger, MainSiteContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = GenerateViewModel();

            return View(viewModel);
        }

        [HttpGet("{slug}")]
        public IActionResult ProjectLanding(string slug)
        {
            var viewModel = GenerateProjectViewModel(slug);

            if (viewModel == null)
            {
                return NotFound(slug);
            }

            return View(viewModel);
        }

        private PortfolioPageViewModel GenerateViewModel()
        {
            var viewModel = new PortfolioPageViewModel();
            viewModel.ProjectData = GenerateProjectsViewModel();
            viewModel.PortfolioData = GeneratePortfolioViewModel();

            return viewModel;
        }

        private PortfolioViewModel GeneratePortfolioViewModel()
        {
            var viewModel = new PortfolioViewModel();

            var groups = (from lgroups in _context.LinkGroups
                          select lgroups).ToList();

            if (groups.Any())
            {
                viewModel.LinkGroups = new List<PortfolioGroupViewModel>();

                foreach (var lgroup in groups)
                {
                    var pgvm = new PortfolioGroupViewModel
                    {
                        GroupName = lgroup.GroupName
                    };

                    var links = (from plinks in _context.PortfolioLinks
                                 where plinks.LinkGroupId == lgroup.LinkGroupId
                                 select plinks).ToList();

                    if (links.Any())
                    {
                        pgvm.Links = new List<PortfolioLinkViewModel>();

                        links.ForEach(x => pgvm.Links.Add(new PortfolioLinkViewModel { Link = x.Link, Text = x.Text }));
                    }

                    viewModel.LinkGroups.Add(pgvm);
                }
            }

            return viewModel;
        }

        private ProjectsViewModel GenerateProjectsViewModel()
        {
            var viewModel = new ProjectsViewModel();
            viewModel.Projects = new List<ProjectViewModel>();

            var projects = (from projs in _context.Projects
                            select projs.ProjectId).ToList();

            if (projects.Any())
            {
                projects.ForEach(x => viewModel.Projects.Add(GenerateProjectViewModel(x)));
            }

            return viewModel;
        }

        private ProjectViewModel GenerateProjectViewModel(string slug)
        {
            var projectId = (from proj in _context.Projects
                             where proj.ProjectSlug== slug
                             select proj.ProjectId).FirstOrDefault();

            if (projectId != Guid.Empty)
            {
                return GenerateProjectViewModel(projectId);
            }

            return null;
        }

        private ProjectViewModel GenerateProjectViewModel(Guid projectId)
        {
            var viewModel = new ProjectViewModel();

            var project = (from proj in _context.Projects
                           where proj.ProjectId.ToString() == projectId.ToString()
                           select proj).FirstOrDefault();

            var platforms = (from projplat in _context.ProjectPlatforms
                             join plat in _context.Platforms on projplat.PlatformId equals plat.PlatformId
                             where projplat.ProjectId == project.ProjectId
                             select plat.Name).ToList();

            var platform = platforms == null ? string.Empty : string.Join(",", platforms);

            if (project == null)
            {
                return null;
            }

            viewModel = new ProjectViewModel
            {
                Name = project.Name,
                Description = project.Description,
                DownloadUrl = project.DownloadUrl,
                LanguageUsed = project.LanguageUsed,
                LibrariesUsed = project.LibrariesUsed,
                NetVersion = project.NetVersion,
                RepositoryType = project.RepositoryType.ToString(),
                RepositoryUrl = project.RepositoryUrl,
                ShortDescription = project.ShortDescription,
                Slug = project.ProjectSlug,
                Platform = platform,
                ProjectType = project.ProjectType.ToString()
            };

            //we need to check for images and extra links
            var projectImages = (from pimg in _context.ProjectImages
                                 where pimg.ProjectId.ToString() == projectId.ToString()
                                 select pimg).ToList();

            if (projectImages.Any())
            {
                viewModel.Images = new List<ProjectImageViewModel>();

                projectImages.ForEach(x => 
                    viewModel.Images.Add(new ProjectImageViewModel
                    {
                        AltText = x.AltText,
                        ImageUrl = x.Url
                    }));
            }

            var projectLinks = (from plink in _context.ProjectLinks
                                where plink.ProjectId.ToString() == projectId.ToString()
                                select plink).ToList();

            if (projectLinks.Any())
            {
                viewModel.AdditionalLinks = new List<ProjectLinkViewModel>();

                projectLinks.ForEach(x =>
                    viewModel.AdditionalLinks.Add(new ProjectLinkViewModel
                    {
                        LinkText = x.Text,
                        LinkUrl = x.Url
                    }));
            }

            return viewModel;
        }
    }
}
