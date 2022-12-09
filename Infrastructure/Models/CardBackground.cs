using System;

namespace Infrastructure.Models
{
    public class CardBackground
    {
        public Guid CardBackgroundId { get; set; }
        public Guid TagId { get; set; }
        public string ImageFilename { get; set; }
        public string TitleFontColor { get; set; }
        public string DescriptionFontColor { get; set; }
    }
}
