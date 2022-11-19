using Infrastructure.Contexts;
using MainSite.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MainSite.Controllers
{
    public class ObjectivesController : Controller
    {
        private readonly ILogger<ObjectivesController> _logger;
        private readonly MainSiteContext _context;

        public ObjectivesController(ILogger<ObjectivesController> logger, MainSiteContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = GenerateViewModel();

            return View(viewModel);
        }

        private ObjectivesViewModel GenerateViewModel()
        {
            var viewModel = new ObjectivesViewModel();

            var objectives = (from objs in _context.Objectives
                              select objs).ToList();

            if (objectives.Any())
            {
                viewModel.Objectives = new List<ObjectiveViewModel>();

                foreach (var objective in objectives)
                {
                    var details = (from objdeets in _context.ObjectivesDetails
                                   where objdeets.ObjectiveId == objective.ObjectiveId
                                   select objdeets).ToList();

                    var objViewModel = new ObjectiveViewModel
                    {
                        Description = objective.Description,
                        Name = objective.Name,
                        Details = new List<ObjectiveDetailViewModel>()
                    };

                    details.ForEach(x => objViewModel.Details.Add(new ObjectiveDetailViewModel { Name = x.Name, LinkUrl = x.LinkUrl }));

                    viewModel.Objectives.Add(objViewModel);
                }
            }

            return viewModel;
        }
    }
}
