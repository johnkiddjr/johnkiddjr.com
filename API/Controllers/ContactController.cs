using API.ViewModels;
using Infrastructure.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly MainSiteContext context;

        public ContactController(MainSiteContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var viewModel = GenerateViewModel();

            return Ok(viewModel);
        }

        private ContactViewModel GenerateViewModel()
        {
            var viewModel = new ContactViewModel();

            var details = (from contacts in context.Contacts
                           select contacts).FirstOrDefault();

            if (details is not null)
            {
                viewModel.ContactDetails = new ContactDetailsViewModel
                {
                    EmailAddress = details.EmailAddress,
                    HeaderText = details.HeaderText,
                    Name = details.Name
                };

                if (details.ResumeId != Guid.Empty)
                {
                    var resume = (from file in context.Files
                                  where file.FileId == details.ResumeId
                                  select file).FirstOrDefault();

                    if (resume is not null)
                    {
                        viewModel.Resume = new FileViewModel
                        {
                            FileData = resume.FileData,
                            FileName = resume.FileName
                        };
                    }
                }
            }

            return viewModel;
        }
    }
}
