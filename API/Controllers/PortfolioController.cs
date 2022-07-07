using API.ViewModels;
using Infrastructure.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly MainSiteContext context;

        public PortfolioController(MainSiteContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var viewModel = GenerateViewModel();

            return Ok(viewModel);
        }

        private PortfolioViewModel GenerateViewModel()
        {
            var viewModel = new PortfolioViewModel();

            var groups = (from lgroups in context.LinkGroups
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

                    var links = (from plinks in context.PortfolioLinks
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
    }
}
