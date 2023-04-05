using System.Collections.Generic;

namespace MatchScore.Web.ViewModels.PlayerViewModels
{
    public class PlayersIndexVM
    {
        public List<PlayerShortVM> Players;
        public bool HasPrevPage;
        public bool HasNextPage;
        public int CurrentPage;
    }
}

