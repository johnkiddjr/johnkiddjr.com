using System;

namespace Infrastructure.Models
{
    public class ProjectPlatform
    {
        public Guid ProjectPlatformId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid PlatformId { get; set; }
    }
}
