using MatchScore.Data.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MatchScore.Data.Models
{
    public class SportsClub
    {
        [Key]
        public int SportsClubId { get; set; }

        [StringLength(40, MinimumLength = 4, ErrorMessage = Messages.StringMinMaxLengthError)]
        public string Name { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();

        public bool IsDeleted { get; set; }
    }
}
