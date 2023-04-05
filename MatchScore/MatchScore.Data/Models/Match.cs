using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MatchScore.Data.Models
{
    public abstract class Match
    {
        [Key]
        public int MatchId { get; set; }

        public DateTime Date { get; set; }

        // Foreign key
        public int? EventId { get; set; }
        // Navigation property
        public Event Event { get; set; }

        // Foreign key
        public int LocationId { get; set; }
        // Navigation property
        public Location Location { get; set; }

        public List<Score> Scores { get; set; } = new List<Score>();

        public bool IsDeleted { get; set; }
    }
}
