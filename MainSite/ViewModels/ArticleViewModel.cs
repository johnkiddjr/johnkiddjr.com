namespace MainSite.ViewModels
{
    public class ArticleViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string PreviewText { get; set; } = string.Empty;
        public string HtmlText { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public List<TagViewModel> Tags { get; set; }
        public bool Visible { get; set; } = false;
    }
}
