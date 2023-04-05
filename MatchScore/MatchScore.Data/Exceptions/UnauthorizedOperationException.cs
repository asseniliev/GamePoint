using System;

namespace MatchScore.Exceptions
{
    public class UnauthorizedOperationException : ApplicationException
    {
        public UnauthorizedOperationException(string message) : base(message)
        {

        }
    }
}
