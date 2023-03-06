using System;

namespace Infrastructure.Models
{
    public class ProjectLink
    {
        public Guid ProjectLinkId { get; set; }
        public Guid ProjectId { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
    }
}
