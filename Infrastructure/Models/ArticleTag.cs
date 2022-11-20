using System;

namespace Infrastructure.Models
{
    public class ArticleTag
    {
        public Guid ArticleTagId { get; set; }
        public Guid ArticleId { get; set; }
        public Guid TagId { get; set; }
    }
}
