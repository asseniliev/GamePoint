namespace MatchScore.Data.Models.QueryParameters
{
    public class AwardQueryParameters : QueryParameters
    {
        public int? EventId { get; set; }

        public string EventTitle { get; set; }

        public decimal? PrizeUpLimit { get; set; }

        public decimal? PrizeDownLimit { get; set; }
    }
}
