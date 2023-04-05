using MatchScore.Data.Models;
using MatchScore.Web.ViewModels.MatchViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchScore.Web.ViewModels.EventViewModels
{
    public class SingleRoundEventVM
    {
        public int EventId { get; set; }

        public string Title { get; set; }
        
        public DateTime eventDate { get; set; }
        
        public int MatchId { get; set; }

        public Player Player1 { get; set; }

        public Player Player2 { get; set; }

        public double? Player1Score { get; set; }
        
        public double? Player2Score { get; set; }
    }
}
