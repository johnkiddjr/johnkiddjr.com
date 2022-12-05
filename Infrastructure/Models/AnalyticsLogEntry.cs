using System;

namespace Infrastructure.Models
{
    public class AnalyticsLogEntry
    {
        public Guid AnalyticsLogEntryId { get; set; }
        public string ApplicationName { get; set; }
        public DateTime VisitDate { get; set; }
        public string VisitorIpAddress { get; set; }
        public string RequestPath { get; set; }
        public string QueryStringValue { get; set; }
        public string ReferrerValue { get; set; }
        public string UserAgentValue { get; set; }
    }
}
