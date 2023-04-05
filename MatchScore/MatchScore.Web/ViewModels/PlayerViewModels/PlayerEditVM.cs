using MatchScore.Data.Constants;
using MatchScore.Data.Enums;
using MatchScore.Data.Models;
using MatchScore.Web.ViewModels.SportsClubViewModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MatchScore.Web.ViewModels.PlayerViewModels
{
    public class PlayerEditVM
    {
        public int PlayerId { get; set; }

        [StringLength(40, MinimumLength = 4, ErrorMessage = Messages.StringMinMaxLengthError)]
        public string Name { get; set; }

        public IFormFile Photo { get; set; }

        public Countries Country { get; set; }

        public int SportsClubId { get; set; }

        public bool IsInactive { get; set; }

        public List<SportsClubDetailsVM> SportsClubs { get; set; } = new List<SportsClubDetailsVM>();

        [StringLength(40, MinimumLength = 4, ErrorMessage = Messages.StringMinMaxLengthError)]
        public string NewSportsClub { get; set; }

        public string View { get; set; }
    }
}

