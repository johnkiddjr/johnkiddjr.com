using Infrastructure.Contexts;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace MainSite.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighScoreController : ControllerBase
    {
        private readonly ILogger<HighScoreController> _logger;
        private readonly MainSiteContext _context;

        public HighScoreController(ILogger<HighScoreController> logger, MainSiteContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [HttpGet("{count}")]
        public IActionResult GetHighScores(int count = 20)
        {
            if (count < 0)
            {
                count = 20;
            }

            var highScores = (from score in _context.HighScores
                              orderby score.Score descending
                              select new { score.Name, score.Score, score.SubmissionDate }).Take(count).ToList();

            return Ok(highScores);
        }

        [HttpPost]
        public IActionResult PostNewHighScore(string name, int score)
        {
            _context.HighScores.Add(new HighScore { Name = name, Score = score, SubmissionDate = DateTime.Now });
            
            return Ok(_context.SaveChanges());
        }
    }
}
