using System;

namespace Infrastructure.Models
{
    public class AdminSectionItem
    {
        public Guid AdminSectionItemId { get; set; }
        public Guid AdminSectionId { get; set; }
        public string LinkText { get; set; }
        public string LinkUrl { get; set; }
    }
}
