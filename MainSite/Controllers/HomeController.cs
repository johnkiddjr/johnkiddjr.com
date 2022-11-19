using Infrastructure.Contexts;
using MainSite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MainSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MainSiteContext _context;

        public HomeController(ILogger<HomeController> logger, MainSiteContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = GenerateHomeViewModel();

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private HomeViewModel GenerateHomeViewModel()
        {
            var viewModel = new HomeViewModel();

            var pageContent = (from ov in _context.Overviews
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