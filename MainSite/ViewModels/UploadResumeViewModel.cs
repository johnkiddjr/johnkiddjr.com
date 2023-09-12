using System.ComponentModel.DataAnnotations;

namespace MainSite.ViewModels
{
    public class UploadResumeViewModel
    {
        [Required]
        [Display(Name = "Replacement Resume")]
        public IFormFile Content { get; set; }
    }
}
