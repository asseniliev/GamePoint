using MatchScore.Data.Constants;
using MatchScore.Data.Enums;
using MatchScore.Data.Models;
using MatchScore.Exceptions;

namespace MatchScore.Services.Helpers
{
    public static class AuthorizationHelper
    {
        public static void AdminDirectorOrPlayer(User user, int playerId)
        {
            if (user.Role != Roles.Director && user.Role != Roles.Admin && (user.Player != null && user.Player.PlayerId != playerId))
            {
                throw new UnauthorizedOperationException(Messages.UnauthorizedError);
            }
        }

        public static void AdminOrDirector(User user)
        {
            if (user.Role != Roles.Director && user.Role != Roles.Admin)
            {
                throw new UnauthorizedOperationException(Messages.UnauthorizedError);
            }
        }

        public static void Active(User user)
        {
            if (user.IsInactive)
            {
                throw new UnauthorizedOperationException(Messages.DeactivatedUserError);
            }
        }

        public static void Completed(Event @event)
        {
            if (@event.IsCompleted)
            {
                throw new UnauthorizedOperationException(Messages.CompletedEventError);
            }
        }
    }
}

