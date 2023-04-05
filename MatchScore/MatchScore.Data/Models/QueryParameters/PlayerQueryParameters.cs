using System;
using MatchScore.Data.Enums;

namespace MatchScore.Data.Models.QueryParameters
{
    public class PlayerQueryParameters
    {
        public string Name { get; set; }
        public Countries Country { get; set; }
        public string SportsClub { get; set; }
        public string Active { get; set; }

        public string SortBy { get; set; } //name, matches played, wins
        public string SortOrder { get; set; }

        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 12;
    }
}

