using System;

namespace MatchScore.Data.Models.QueryParameters
{
    public class EventQueryParameters : QueryParameters
    {
        public string Title { get; set; }

        public int? EventType { get; set; }

        // Selection Interval Start and End Dates
        public DateTime IntervalStartDate { get; set; }

        public DateTime IntervalEndDate { get; set; }

        public bool? IsTeamEvent { get; set; }

        public string Champion { get; set; }

        public string Director { get; set; }

        public override int PageSize { get; set; } = 6;
    }
}
