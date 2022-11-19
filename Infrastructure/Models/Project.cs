using System;

namespace Infrastructure.Models
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public string DirectUrl { get; set; }
    }
}
