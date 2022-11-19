using Infrastructure.Contexts;
using MainSite.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MainSite.Controllers
{
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

            var projects = (from projs in _context.Projects
                            select projs).ToList();

            if (projects.Any())
            {
                viewModel.Projects = new List<ProjectViewModel>();

                projects.ForEach(x => viewModel.Projects.Add(new ProjectViewModel
                {
                    Name = x.Name,
                    Description = x.Description,
                    DirectUrl = x.DirectUrl,
                    PictureUrl = x.PictureUrl
                }));
            }

            return viewModel;
        }
    }
}
