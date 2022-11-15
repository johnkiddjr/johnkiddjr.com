using System;

namespace Infrastructure.Models
{
    public class Article
    {
        public Guid ArticleId { get; set; }
        public string Slug { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string PreviewText { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public Guid AuthorId { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime AvailableDate { get; set; }
        public bool Visible { get; set; } = false;
    }
}