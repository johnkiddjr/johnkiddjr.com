using API.ViewModels;
using Infrastructure.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly MainSiteContext context;

        public HomeController(MainSiteContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var viewModel = GenerateHomeViewModel();

            return Ok(viewModel);
        }

        private HomeViewModel GenerateHomeViewModel()
        {
            var viewModel = new HomeViewModel();

            var pageContent = (from ov in context.Overviews
                               orderby ov.CreatedDate descending
                               select ov).FirstOrDefault();

            if (pageContent is not null)
            {
                viewModel.HeaderText = pageContent.HeaderText;
                viewModel.BodyHtml = pageContent.BodyHtml;
            }

            return viewModel;
        }
    }
}
