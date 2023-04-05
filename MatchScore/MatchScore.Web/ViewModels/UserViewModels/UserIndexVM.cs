namespace MatchScore.Web.ViewModels.UserViewModels
{
    public class UserIndexVM
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Role { get; set; }

        public int? PlayerId { get; set; }

        public string PlayerName { get; set; }

        public int EventsCount { get; set; }

        public bool IsInactive { get; set; }
    }
}
