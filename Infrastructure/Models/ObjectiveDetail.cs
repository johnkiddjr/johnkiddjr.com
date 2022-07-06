using System;

namespace Infrastructure.Models
{
    public class ObjectiveDetail
    {
        public Guid ObjectiveDetailId { get; set; }
        public Guid ObjectiveId { get; set; }
        public string? Name { get; set; }
        public string? LinkUrl { get; set; }
    }
}
