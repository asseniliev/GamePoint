using MatchScore.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace MatchScore.Web.DTOs.UserDTOs
{
    public class UserPostDto
    {
        [StringLength(32, MinimumLength = 4, ErrorMessage = Messages.StringMinMaxLengthError)]
        public string Username { get; set; }

        [StringLength(32, MinimumLength = 4, ErrorMessage = Messages.StringMinMaxLengthError)]
        public string Password { get; set; }

        [EmailAddress(ErrorMessage = Messages.InvalidEmailError)]
        public string Email { get; set; }
    }
}
