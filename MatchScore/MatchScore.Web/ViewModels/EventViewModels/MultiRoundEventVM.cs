using MatchScore.Web.ViewModels.MatchViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchScore.Web.ViewModels.EventViewModels
{
    public class MultiRoundEventVM
    {
        //List "MatchScheme": 
        //The index + 1 is the number of the round
        //The list for that index contains the list of the matches in that round
        public List<List<MatchDetailsVM>> MatchScheme { get; set; } = new List<List<MatchDetailsVM>>();

        //List "MatchIDsWithScores" contains the matches that have scores already registered
        public List<int> MatchIDsWithScores { get; set; } = new List<int>();        

        //Dictionary with match scores;
        //The key is the matchId and the list contains the scores of the two players
        public Dictionary<int, List<double?>> MatchScores { get; set; } = new Dictionary<int, List<double?>>();

        public int EventId { get; set; }
        
        public string Title { get; set; }

        public DateTime EventEndDate { get; set; }
        
        public int MatchId { get; set; }
        
        public int Player1Score { get; set; }
        
        public int Player2Score { get; set; }

        //List "DependentMatchesIDs" contains matches that already have subsequent matches with recorded results
        public List<int> DependentMatchesIDs { get; set; } = new List<int>();
    }
}
