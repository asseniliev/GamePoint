using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using System.Collections.Generic;

namespace MatchScore.Data.Repositories.Contracts
{
    public interface IPlayersRepository
    {
        List<Player> GetAll();

        Player GetById(int playerId);

        Player GetByName(string playerName);

        PaginatedList<Player> FilterBy(PlayerQueryParameters parameters);

        Player Create(Player player);

        void Update(Player player);

        void SaveDatabase();
    }
}

