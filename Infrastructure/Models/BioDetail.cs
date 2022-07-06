using System;

namespace Infrastructure.Models
{
    public class BioDetail
    {
        public Guid BioDetailId { get; set; }
        public Guid BioId { get; set; }
        public Guid BioSectionId { get; set; }
        public string? Description { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
