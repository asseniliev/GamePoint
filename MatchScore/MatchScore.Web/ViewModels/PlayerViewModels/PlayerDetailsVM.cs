using System.Collections.Generic;
using MatchScore.Web.ViewModels.EventViewModels;
using MatchScore.Web.ViewModels.MatchViewModels;

namespace MatchScore.Web.ViewModels.PlayerViewModels
{
    public class PlayerDetailsVM
    {
        public int PlayerId { get; set; }

        //[StringLength(40, MinimumLength = 4, ErrorMessage = Messages.StringMinMaxLengthError)]
        public string Name { get; set; }

        public byte[] Photo { get; set; }

        public bool IsTeam { get; set; }

        public string Country { get; set; }

        public int SportsClubId { get; set; }

        //[StringLength(40, MinimumLength = 4, ErrorMessage = Messages.StringMinMaxLengthError)]
        public string SportsClubName { get; set; }

        public List<EventShortVM> Events { get; set; } = new List<EventShortVM>();

        public List<MatchShortVM> Matches { get; set; } = new List<MatchShortVM>();

        // Statistics: wins, draws, losses
        public int Wins { get; set; }

        public int Draws { get; set; }

        public int Losses { get; set; }

        //public int MostPlayedOpponentId { get; set; }

        //public string MostPlayedOpponentName { get; set; }

        //public int BestOpponentId { get; set; }

        //public string BestOpponentName { get; set; }

        //public int WorstOpponentId { get; set; }

        //public string WorstOpponentName { get; set; }

        public bool IsInactive { get; set; }

        public PlayerShortVM MostPlayedOpponent { get; set; }

        public PlayerShortVM BestOpponent { get; set; }

        public PlayerShortVM WorstOpponent { get; set; }
    }
}

