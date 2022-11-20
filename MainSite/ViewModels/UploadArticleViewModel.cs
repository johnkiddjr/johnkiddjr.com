using System.ComponentModel.DataAnnotations;

namespace MainSite.ViewModels
{
    public class UploadArticleViewModel
    {
        [Required]
        [Display(Name = "Article Content")]
        public IFormFile Content { get; set; }
        [Required]
        [Display(Name = "Article Slug")]
        public string Slug { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Article Title")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Preview Text")]
        [StringLength(300, MinimumLength = 75)]
        public string PreviewText { get; set; } = string.Empty;
        [Display(Name = "Article Tags")]
        public string Tags { get; set; }
        [Required]
        [Display(Name = "Date Article Available")]
        public DateTime AvailableDate { get; set; } = DateTime.Now;
        [Display(Name = "Make Article Visible?")]
        public bool Visible { get; set; } = false;
    }
}