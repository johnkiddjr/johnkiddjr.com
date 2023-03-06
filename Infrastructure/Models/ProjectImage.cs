using System;

namespace Infrastructure.Models
{
    public class ProjectImage
    {
        public Guid ProjectImageId { get; set; }
        public Guid ProjectId { get; set; }
        public string Url { get; set; }
        public string AltText { get; set; }
    }
}
