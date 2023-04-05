using MatchScore.Data.Constants;
using MatchScore.Web.ViewModels.EventViewModels;
using MatchScore.Web.ViewModels.PlayerViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MatchScore.Web.ViewModels.UserViewModels
{
    public class UserEditVM
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = Messages.RequiredError)]
        public string CurrentPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = Messages.RequiredError)]
        [StringLength(32, MinimumLength = 4, ErrorMessage = Messages.StringMinMaxLengthError)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = Messages.RequiredError)]
        public string ConfirmNewPassword { get; set; }

        public string Role { get; set; }

        public int? PlayerId { get; set; }

        public string PlayerName { get; set; }

        public List<PlayerShortVM> Players { get; set; }

        public bool IsInactive { get; set; }

        public bool IsDeleted { get; set; }
    }
}
