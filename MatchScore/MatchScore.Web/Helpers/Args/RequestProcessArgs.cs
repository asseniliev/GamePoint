using MatchScore.Data.Models;
using System;

namespace MatchScore.Web.Helpers.Args
{
    public class RequestProcessArgs : EventArgs
    {
        public Request Request { get; set; }
    }
}
