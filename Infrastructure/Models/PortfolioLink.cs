using System;

namespace Infrastructure.Models
{
    public class PortfolioLink
    {
        public Guid PortfolioLinkId { get; set; }
        public Guid LinkGroupId { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
    }
}
