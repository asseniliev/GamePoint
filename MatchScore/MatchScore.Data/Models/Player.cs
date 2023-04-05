using MatchScore.Data.Constants;
using MatchScore.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MatchScore.Data.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [StringLength(40, MinimumLength = 4, ErrorMessage = Messages.StringMinMaxLengthError)]
        public string Name { get; set; }

        public byte[] Photo { get; set; }

        public bool IsTeam { get; set; }

        public Countries? Country { get; set; }

        // Foreign key
        public int? SportsClubId { get; set; }
        // Navigation property
        public SportsClub SportsClub { get; set; }

        public List<Score> Scores { get; set; } = new List<Score>();

        public List<Ranking> Rankings { get; set; } = new List<Ranking>();

        public bool IsInactive { get; set; }

        public bool IsDeleted { get; set; }
    }
}
