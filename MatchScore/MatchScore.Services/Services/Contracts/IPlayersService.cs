using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using System.Collections.Generic;

namespace MatchScore.Services.Services.Contracts
{
    public interface IPlayersService
    {
        // Methods for other services:
        List<Player> GetAll();

        Player GetByName(string playerName);

        Player CreateAuto(Player player);
        // end

        PaginatedList<Player> FilterBy(PlayerQueryParameters parameters);

        Player GetById(int playerId);

        Player Create(Player player, User user);

        Player Update(Player playerWithEditedInfo, User user);

        void Delete(int playerId, User user);
    }
}

