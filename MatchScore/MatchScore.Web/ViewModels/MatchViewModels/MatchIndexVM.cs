using System;
using System.Collections.Generic;

namespace MatchScore.Web.ViewModels.MatchViewModels
{
    public class MatchIndexVM
    {
        public List<MatchShortVM> Matches;
        public bool HasPrevPage;
        public bool HasNextPage;
        public int CurrentPage;
    }
}

