using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Data.Repositories.Contracts;
using MatchScore.Services.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MatchScore.Services.Services
{
    public class AwardsService : IAwardsService
    {
        #region Constructors

        private readonly IAwardsRepository awardRepository;

        public AwardsService(IAwardsRepository awardRepository)
        {
            this.awardRepository = awardRepository;
        }

        #endregion


        #region Get Methods
        public Award GetByAwardId(int awardId)
        {
            return this.awardRepository.GetByAwardId(awardId);
        }

        public Award GetByEventIdAndRank(int eventId, int rank)
        {
            return this.GetByEventIdAndRank(eventId, rank);
        }

        public List<Award> GetByEventId(int eventId)
        {
            return this.awardRepository.GetByEventId(eventId);
        }

        public PaginatedList<Award> FilterBy(AwardQueryParameters parameters)
        {
            return this.awardRepository.FilterBy(parameters);
        }
        #endregion


        #region Updates
        public Award Create(Award award)
        {
            return this.awardRepository.Create(award);
        }

        public Award Update(Award awardUpdates)
        {
            Award awardToUpdate = this.awardRepository.GetByAwardId(awardUpdates.AwardId);

            awardToUpdate.Prize = awardUpdates.Prize;

            this.awardRepository.Update(awardToUpdate);

            this.awardRepository.SaveDatabase();

            Award updatedAward = this.awardRepository.GetByAwardId(awardUpdates.AwardId);

            return updatedAward;
        }

        public void Delete(int awardId)
        {
            Award awardToDelete = this.awardRepository.GetByAwardId(awardId);

            awardToDelete.IsDeleted = true;

            this.awardRepository.Update(awardToDelete);

            this.awardRepository.SaveDatabase();
        }

        public void Delete(List<Award> awardsToDelete)
        {
            awardsToDelete.ForEach(a => a.IsDeleted = true);

            awardsToDelete.ForEach(a => this.awardRepository.Update(a));

            this.awardRepository.SaveDatabase();
        }
        #endregion







    }
}
