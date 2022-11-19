using System;

namespace Infrastructure.Models
{
    public class Objective
    {
        public Guid ObjectiveId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
