using MatchScore.Data.Models;
using System.Collections.Generic;

namespace MatchScore.Data.Repositories.Contracts
{
    public interface IRankingsRepository
    {
        Ranking Create(Ranking rankingToCreate);

        List<Ranking> GetAll();

        List<Ranking> GetByIDs(int eventId);

        Ranking GetByIDs(int? playerId, int? eventId);

        Ranking GetByIdWithDeleted(int? playerId, int? eventId);

        List<Ranking> GetByIdWithDeleted(int? eventId);

        void Update(Ranking rankingToUpdate);

        void SaveDatabase();
    }
}
