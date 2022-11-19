using System;

namespace Infrastructure.Models
{
    public class Contact
    {
        public Guid ContactId { get; set; }
        public string Name { get; set; }
        public string HeaderText { get; set; }
        public string EmailAddress { get; set; }
        public Guid ResumeId { get; set; }
    }
}
