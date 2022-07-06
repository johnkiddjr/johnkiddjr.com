using System;

namespace Infrastructure.Models
{
    public class Bio
    {
        public Guid BioId { get; set; }
        public string? Name { get; set; }
        public string? PictureUrl { get; set; }
    }
}
