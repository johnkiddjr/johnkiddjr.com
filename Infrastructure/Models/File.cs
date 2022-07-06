using System;

namespace Infrastructure.Models
{
    public class File
    {
        public Guid FileId { get; set; }
        public string? FileName { get; set; }
        public byte[]? FileData { get; set; }
    }
}
