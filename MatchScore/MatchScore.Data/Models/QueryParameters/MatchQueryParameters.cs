using System;

namespace MatchScore.Data.Models.QueryParameters
{
    public class MatchQueryParameters
    {
        public DateTime Date { get; set; }
        public string Player { get; set; }
        public string City { get; set; }
        public string EventTitle { get; set; }

        public string SortBy { get; set; } //date
        public string SortOrder { get; set; }

        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}

