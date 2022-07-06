using API.ViewModels;
using Infrastructure.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly MainSiteContext context;

        public AboutController(MainSiteContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var viewModel = GenerateAboutViewModel();

            return Ok(viewModel);
        }

        private AboutViewModel GenerateAboutViewModel()
        {
            var viewModel = new AboutViewModel();

            var bioSections = context.BioSections;

            if (bioSections is null)
            {
                return viewModel;
            }

            var bioData = (from bios in context.Bios
                           select bios).FirstOrDefault();

            if (bioData is null)
            {
                return viewModel;
            }

            var bioDetails = (from biodetails in context.BioDetails
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
    }
}
