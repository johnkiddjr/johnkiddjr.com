using System;

namespace Infrastructure.Models
{
    public class PrivacyPolicy
    {
        public Guid PrivacyPolicyId { get; set; }
        public DateTime ValidFrom { get; set; } = DateTime.Now;
        public DateTime? ValidUntil { get; set; } = null;
        public string PolicyMarkdownName { get; set; }
    }
}
