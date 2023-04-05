using System;
namespace MatchScore.Exceptions
{
    public class DeleteConnectedEntityException : ApplicationException
    {
        public DeleteConnectedEntityException(string message)
            : base(message)
        {
        }
    }
}

