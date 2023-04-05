namespace MatchScore.Web.ViewModels.RequestViewModels
{
    public class RequestCreateVM
    {
        public int UserId { get; set; }

        public string RequestType { get; set; }

        public int? PlayerId { get; set; }

        public string PlayerName { get; set; }
    }
}
