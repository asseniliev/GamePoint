namespace MatchScore.Data.Models.QueryParameters
{
    public class ScoreQueryParameters : QueryParameters
    {
        public int? MatchId { get; set; }

        public int? PlayerId { get; set; }

        public string PlayerName { get; set; }

        public double? PlayerScoreUpLimit { get; set; }

        public double? PlayerScoreDownLimit { get; set; }
    }
}
