namespace MatchScore.Data.Models
{
    public class TimeLimitedMatch : Match
    {
        public int PlayerTimeLimit { get; set; }

        public int MatchTimeLimit { get; set; }
    }
}
