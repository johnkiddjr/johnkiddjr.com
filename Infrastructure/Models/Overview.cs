using System;

namespace Infrastructure.Models
{
    public class Overview
    {
        public Guid OverviewId { get; set; }
        public string? HeaderText { get; set; }
        public string? BodyHtml { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
