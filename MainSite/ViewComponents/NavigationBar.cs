using Infrastructure.Contexts;
using Infrastructure.Models.Identity;
using MainSite.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MainSite.ViewComponents
{
    public class NavigationBar : ViewComponent
    {
        private readonly MainSiteContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public NavigationBar(MainSiteContext context, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _signInManager = signInManager;
            _contextAccessor = contextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = await ConstructViewModel();

            return View(viewModel);
        }

        private async Task<NavigationBarViewModel> ConstructViewModel()
        {
            var viewModel = new NavigationBarViewModel
            {
                AdminLoggedIn = _signInManager.IsSignedIn(_contextAccessor.HttpContext.User)
            };

            return viewModel;
        }
    }
}
