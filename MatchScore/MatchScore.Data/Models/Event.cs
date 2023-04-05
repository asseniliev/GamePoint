using MatchScore.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MatchScore.Data.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        public string Title { get; set; }

        public EventTypes EventType { get; set; }

        //public List<Player> Players { get; set; } = new List<Player>();

        public List<Ranking> Ranking { get; set; } = new List<Ranking>();

        public List<Match> Matches { get; set; } = new List<Match>();

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<Award> Awards { get; set; } = new List<Award>();

        public bool IsTeamEvent { get; set; }

        // Foreign key
        public int LocationId { get; set; }
        // Navigation property
        public Location Location { get; set; }

        public MatchTypes matchType { get; set; }

        public int MatchLimitValue { get; set; }

        public int ScoreForWin { get; set; }

        public int ScoreForDraw { get; set; }

        // Foreign key
        public int? ChampionId { get; set; }
        // Navigation property
        public Player Champion { get; set; }

        // Foreign key
        public int? DirectorId { get; set; }
        // Navigation property
        public User Director { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsDeleted { get; set; }
    }
}
