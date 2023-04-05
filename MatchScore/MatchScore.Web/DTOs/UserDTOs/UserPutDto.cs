using MatchScore.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace MatchScore.Web.DTOs.UserDTOs
{
    public class UserPutDto
    {
        [StringLength(32, MinimumLength = 4, ErrorMessage = Messages.StringMinMaxLengthError)]
        public string Password { get; set; }
    }
}
