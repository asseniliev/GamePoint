using MatchScore.Data.Constants;
using MatchScore.Data.Enums;
using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Data.Repositories.Contracts;
using MatchScore.Exceptions;
using MatchScore.Services.Helpers;
using MatchScore.Services.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MatchScore.Services.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly IPlayersRepository playersRepo;
        private readonly IUsersRepository usersRepo;

        public PlayersService(IPlayersRepository playersRepo, IUsersRepository usersRepo)
        {
            this.playersRepo = playersRepo;
            this.usersRepo = usersRepo;
        }

        #region MethodsForOtherServices
        //TODO remove method if no other service uses it

        public List<Player> GetAll()
        {
            var players = this.playersRepo.GetAll();
            return players;
        }

        public Player GetByName(string playerName)
        {
            var player = this.playersRepo.GetByName(playerName);
            return player;
        }

        public Player CreateAuto(Player player)
        {
            // Check if player with the same name exists:
            try
            {
                var repeatedPlayer = this.playersRepo.GetByName(player.Name);
                throw new DuplicateEntityException(string.Format(Messages.AlreadyExistsError, "Player", "name", player.Name));
            }
            catch (EntityNotFoundException)
            {
                var result = this.playersRepo.Create(player);
                return result;
            }
        }

        public void Delete(List<Player> players)
        {
            foreach (var player in players)
            {
                var playerToDelete = this.playersRepo.GetById(player.PlayerId);
                playerToDelete.IsDeleted = true;
                this.playersRepo.Update(playerToDelete);
            }

            this.playersRepo.SaveDatabase();
        }

        #endregion MethodsForOtherServices

        public PaginatedList<Player> FilterBy(PlayerQueryParameters parameters)
        {
            var players = this.playersRepo.FilterBy(parameters);
            return players;
        }


        public Player GetById(int playerId)
        {
            var player = this.playersRepo.GetById(playerId);
            return player;
        }

        public Player Create(Player player, User user)
        {
            // Authorization: user has to be director or admin
            AuthorizationHelper.AdminOrDirector(user);
            AuthorizationHelper.Active(user);

            // Check if player with the same name, city and country exists
            if (RepeatingPlayer(player) == null)
            {
                var result = this.playersRepo.Create(player);
                return result;
            }
            throw new DuplicateEntityException(string.Format(Messages.AlreadyExistsError, "A player", "the same", "name, country and sports club"));
        }

        public Player Update(Player playerWithUpdates, User user)
        {
            // Authorization: user has to be director, admin or a user with this player profile linked to yours
            AuthorizationHelper.AdminDirectorOrPlayer(user, playerWithUpdates.PlayerId);
            AuthorizationHelper.Active(user);

            // Check if player is associated with user

            var associatedUser = this.usersRepo.GetAll().FirstOrDefault(u => u.PlayerId == playerWithUpdates.PlayerId);
            if (associatedUser != null && (user.Role != Roles.Admin && associatedUser.UserId != user.UserId))
            {
                throw new UnauthorizedOperationException(Messages.UnauthorizedError);
            }

            // Update
            var playerToUpdate = this.playersRepo.GetById(playerWithUpdates.PlayerId);

            var repeatingPlayer = RepeatingPlayer(playerWithUpdates);

            if (repeatingPlayer != null && playerWithUpdates.PlayerId != repeatingPlayer.PlayerId)
            {
                throw new DuplicateEntityException(string.Format(Messages.AlreadyExistsError, "A player", "the same", "name, country and sports club"));
            }

            if (!string.IsNullOrEmpty(playerWithUpdates.Name))
            {
                playerToUpdate.Name = playerWithUpdates.Name;
            }

            //Check if updated photo is not null
            if (playerWithUpdates.Photo != null)
            {
                playerToUpdate.Photo = playerWithUpdates.Photo;
            }

            if (playerWithUpdates.Country != null && playerWithUpdates.Country != 0)
            {
                playerToUpdate.Country = playerWithUpdates.Country;
            }

            if (playerWithUpdates.SportsClubId != null && playerWithUpdates.SportsClubId != 0)
            {
                playerToUpdate.SportsClubId = playerWithUpdates.SportsClubId;
            }

            if (user.Role == Roles.Admin)
            {
                playerToUpdate.IsInactive = playerWithUpdates.IsInactive;
            }

            this.playersRepo.Update(playerToUpdate);
            this.playersRepo.SaveDatabase();
            var updatedPlayer = this.playersRepo.GetById(playerToUpdate.PlayerId);

            return updatedPlayer;
        }

        public void Delete(int playerId, User user)
        {
            // Authorization: user has to be director, admin or a user with this player profile linked to yours
            AuthorizationHelper.AdminDirectorOrPlayer(user, playerId);
            AuthorizationHelper.Active(user);

            // Delete:

            var playerToDelete = this.playersRepo.GetById(playerId);

            // Check if player has linked entities that would prevent deletion: matches, events, or user profile different from the current user profile

            var associatedUser = usersRepo.GetAll().FirstOrDefault(u => u.PlayerId == playerToDelete.PlayerId);
            if (playerToDelete.Scores.Count > 0 || playerToDelete.Rankings.Count > 0 || (associatedUser != null && (user.Role != Roles.Admin && associatedUser.UserId != user.UserId)))
            {
                throw new DeleteConnectedEntityException(string.Format(Messages.DeleteConnectedEntityError, "Player"));
            }

            playerToDelete.IsDeleted = true;
            this.playersRepo.Update(playerToDelete);
            this.playersRepo.SaveDatabase();
        }

        private Player RepeatingPlayer(Player player) =>
            this.playersRepo.GetAll().FirstOrDefault(p =>
            p.Name.ToLower() == player.Name.ToLower()
            && p.Country == player.Country
            && p.SportsClubId == p.SportsClubId);
    }
}

