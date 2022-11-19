using Infrastructure.Contexts;
using MainSite.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MainSite.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly MainSiteContext _context;

        public ContactController(ILogger<ContactController> logger, MainSiteContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = GenerateViewModel();

            return View(viewModel);
        }

        [HttpGet("{controller}/{fileGuid}")]
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

            var details = (from contacts in _context.Contacts
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

        private (string FileName, byte[] FileData) GetFileData(Guid fileId)
        {
            var file = (from files in _context.Files
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
