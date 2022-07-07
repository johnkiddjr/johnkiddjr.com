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

        [HttpGet("{fileGuid}")]
        public IActionResult DownloadFile(string fileGuid)
        {
            if (Guid.TryParse(fileGuid, out var fileId))
            {
                var file = GetFileData(fileId);

                if (file.FileData is null || file.FileName is null)
                {
                    return BadRequest();
                }

                return File(file.FileData, "application/octet-stream", file.FileName);
            }

            return NotFound();
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
                    viewModel.ResumeGuid = details.ResumeId.ToString();
                }
            }

            return viewModel;
        }

        private (string? FileName, byte[]? FileData) GetFileData(Guid fileId)
        {
            var file = (from files in context.Files
                        where files.FileId == fileId
                        select files).FirstOrDefault();

            if (file is null)
            {
                return (null, null);
            }

            return (file.FileName, file.FileData);
        }
    }
}
