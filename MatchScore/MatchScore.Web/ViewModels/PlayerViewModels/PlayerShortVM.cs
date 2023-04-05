using MatchScore.Data.Enums;

namespace MatchScore.Web.ViewModels.PlayerViewModels
{
    public class PlayerShortVM
    {
        public int PlayerId { get; set; }

        public byte[] Photo { get; set; }

        //[StringLength(40, MinimumLength = 4, ErrorMessage = Messages.StringMinMaxLengthError)]
        public string Name { get; set; }

        public Countries Country { get; set; }

        public int SportsClubId { get; set; }

        //[StringLength(40, MinimumLength = 4, ErrorMessage = Messages.StringMinMaxLengthError)]
        public string SportsClubName { get; set; }

        public int MatchesPlayed { get; set; }

        public int MatchesWon { get; set; }

        public bool IsInactive { get; set; }
    }
}

