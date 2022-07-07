using API.ViewModels;
using Infrastructure.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectivesController : ControllerBase
    {
        private readonly MainSiteContext context;

        public ObjectivesController(MainSiteContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var viewModel = GenerateViewModel();

            return Ok(viewModel);
        }

        private ObjectivesViewModel GenerateViewModel()
        {
            var viewModel = new ObjectivesViewModel();

            var objectives = (from objs in context.Objectives
                              select objs).ToList();

            if (objectives.Any())
            {
                viewModel.Objectives = new List<ObjectiveViewModel>();

                foreach (var objective in objectives)
                {
                    var details = (from objdeets in context.ObjectivesDetails
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
