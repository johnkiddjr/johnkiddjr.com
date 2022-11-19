namespace MainSite.ViewModels
{
    public class UploadArticleViewModel
    {
        public IFormFile Content { get; set; }
        public string Slug { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string PreviewText { get; set; } = string.Empty;
        public Guid AuthorId { get; set; } = Guid.Parse("DC635535-81AF-4CB5-A873-869225A41016");
        public DateTime AvailableDate { get; set; } = DateTime.Now;
        public bool Visible { get; set; } = false;
    }
}