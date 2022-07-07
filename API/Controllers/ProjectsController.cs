using API.ViewModels;
using Infrastructure.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly MainSiteContext context;

        public ProjectsController(MainSiteContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var viewModel = GenerateViewModel();

            return Ok(viewModel);
        }

        private ProjectsViewModel GenerateViewModel()
        {
            var viewModel = new ProjectsViewModel();

            var projects = (from projs in context.Projects
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
