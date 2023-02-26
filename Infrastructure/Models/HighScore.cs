using System;

namespace Infrastructure.Models
{
    public class HighScore
    {
        public Guid HighScoreId { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime SubmissionDate {get;set;}
    }
}
