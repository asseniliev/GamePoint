using MatchScore.Data.Constants;
using MatchScore.Data.Enums;
using MatchScore.Data.Models;
using MatchScore.Web.ViewModels.SportsClubViewModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MatchScore.Web.ViewModels.PlayerViewModels
{
    public class PlayerCreateVM
    {
        [Required]
        [StringLength(40, MinimumLength = 4, ErrorMessage = Messages.StringMinMaxLengthError)]
        public string Name { get; set; }

        public IFormFile Photo { get; set; }

        [Required]
        public Countries Country { get; set; }

        [Required]
        public int SportsClubId { get; set; }

        [Required]
        public bool IsTeam { get; set; }

        public List<SportsClubDetailsVM> SportsClubs { get; set; } = new List<SportsClubDetailsVM>();

        [StringLength(40, MinimumLength = 4, ErrorMessage = Messages.StringMinMaxLengthError)]
        public string NewSportsClub { get; set; }

        public string View { get; set; }
    }
}

