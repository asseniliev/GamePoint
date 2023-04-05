using MatchScore.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace MatchScore.Web.ViewModels.UserViewModels
{
    public class UserRegisterVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = Messages.RequiredError)]
        [StringLength(32, MinimumLength = 4, ErrorMessage = Messages.StringMinMaxLengthError)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = Messages.RequiredError)]
        [StringLength(32, MinimumLength = 4, ErrorMessage = Messages.StringMinMaxLengthError)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = Messages.RequiredError)]
        [StringLength(32, MinimumLength = 4, ErrorMessage = Messages.StringMinMaxLengthError)]
        [Display(Name ="Confirm password")]
        public string ConfirmPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = Messages.RequiredError)]
        [EmailAddress(ErrorMessage = Messages.InvalidEmailError)]
        public string Email { get; set; }
    }
}
