namespace MatchScore.Data.Models
{
    public class Ranking
    {
        // Foreign key
        public int EventId { get; set; }

        // Navigation property
        public Event Event { get; set; }

        // Foreign key
        public int PlayerId { get; set; }

        // Navigation property
        public Player Player { get; set; }

        public int Rank { get; set; }

        public bool IsDeleted { get; set; }
    }
}
