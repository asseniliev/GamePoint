using MatchScore.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace MatchScore.Web.ViewModels.UserViewModels
{
    public class UserLoginVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = Messages.UnauthenticatedError)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = Messages.UnauthenticatedError)]
        public string Password { get; set; }
    }
}
