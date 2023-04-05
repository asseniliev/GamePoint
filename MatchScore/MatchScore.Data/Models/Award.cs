using System.ComponentModel.DataAnnotations;

namespace MatchScore.Data.Models
{
    public class Award
    {
        [Key]
        public int AwardId { get; set; }

        // Foreign key
        public int? EventId { get; set; }

        // Navigation property
        public Event Event { get; set; }

        public int Rank { get; set; }

        public decimal Prize { get; set; }

        public bool IsDeleted { get; set; }
    }
}
