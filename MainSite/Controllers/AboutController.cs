using Infrastructure.Contexts;
using MainSite.Options;
using MainSite.Services;
using MainSite.ViewModels;
using Markdig;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MainSite.Controllers
{
    public class AboutController : Controller
    {
        private readonly ILogger<AboutController> _logger;
        private readonly MainSiteContext _context;
        private readonly IMarkdownService _markdownService;
        private readonly CDNOptions _options;

        public AboutController(ILogger<AboutController> logger, MainSiteContext context, IMarkdownService markdownService, IOptions<CDNOptions> options)
        {
            _logger = logger;
            _context = context;
            _markdownService = markdownService;
            _options = options.Value;
        }

        public IActionResult Index()
        {
            var viewModel = GenerateAboutViewModel();

            return View(viewModel);
        }

        [Route("{controller}/Privacy")]
        public async Task<IActionResult> Privacy()
        {
            var viewModel = await GeneratePrivacyViewModel();

            return View(viewModel);
        }

        private AboutViewModel GenerateAboutViewModel()
        {
            var viewModel = new AboutViewModel();

            if (_context.BioSections is null)
            {
                return viewModel;
            }

            var bioSections = _context.BioSections.OrderBy(x => x.Order);

            if (bioSections is null)
            {
                return viewModel;
            }

            var bioData = (from bios in _context.Bios
                           select bios).FirstOrDefault();

            if (bioData is null)
            {
                return viewModel;
            }

            var bioDetails = (from biodetails in _context.BioDetails
                              where biodetails.BioId == bioData.BioId
                              select biodetails).ToList();

            viewModel.Name = bioData.Name;
            viewModel.PictureUrl = bioData.PictureUrl;
            viewModel.Sections = new List<AboutSectionViewModel>();

            foreach (var section in bioSections)
            {
                var sectionViewModel = new AboutSectionViewModel
                {
                    Name = section.Name,
                    Details = new List<AboutDetailViewModel>()
                };

                var sectionDetails = bioDetails.Where(bio => bio.BioSectionId == section.BioSectionId).ToList();

                foreach (var detailItem in sectionDetails)
                {
                    sectionViewModel.Details.Add(new AboutDetailViewModel
                    {
                        Description = detailItem.Description,
                        PhotoUrl = detailItem.PhotoUrl
                    });
                }

                viewModel.Sections.Add(sectionViewModel);
            }

            return viewModel;
        }

        private async Task<PrivacyViewModel> GeneratePrivacyViewModel()
        {
            var currentDT = DateTime.Now;
            var currentPolicy = (from ppolicy in _context.PrivacyPolicies
                                 where ppolicy.ValidFrom < currentDT && (ppolicy.ValidUntil == null || ppolicy.ValidUntil < currentDT)
                                 select ppolicy).FirstOrDefault();

            if (currentPolicy == null)
            {
                return null;
            }

            var documentHtml = await _markdownService.GetHtmlFromMarkdownUrl($"{_options.OtherStub}/{currentPolicy.PolicyMarkdownName}");

            return new PrivacyViewModel()
            {
                PolicyHtml = documentHtml
            };
        }
    }
}
