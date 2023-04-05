namespace MatchScore.Data.Models
{
    public class Score
    {
        // Composite Primary key: MatchId + PlayerId

        // Foreign key
        public int MatchId { get; set; }

        // Navigation property
        public Match Match { get; set; }

        // Foreign key
        public int PlayerId { get; set; }

        // Navigation property
        public Player Player { get; set; }

        public int Round { get; set; }

        public double? PlayerScore { get; set; }

        public int ScoredPoints { get; set; }

        public bool IsDeleted { get; set; }
    }
}
