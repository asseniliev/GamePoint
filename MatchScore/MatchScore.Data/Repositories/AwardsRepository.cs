using MatchScore.Data.Constants;
using MatchScore.Data.Data;
using MatchScore.Data.Helpers;
using MatchScore.Data.Models;
using MatchScore.Data.Models.QueryParameters;
using MatchScore.Data.Repositories.Contracts;
using MatchScore.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MatchScore.Data.Repositories
{
    public class AwardsRepository : IAwardsRepository
    {
        #region Constructors
        private ApplicationContext context;

        public AwardsRepository(ApplicationContext context)
        {
            this.context = context;
        }

        #endregion
        #region Get Methods

        public Award GetByAwardId(int awardId)
        {
            var award = this.GetAwards().FirstOrDefault(a => a.AwardId == awardId);
            return award ?? throw new EntityNotFoundException(string.Format(Messages.DoesNotExistErrorLong, "Award", "id", awardId));
        }

        public List<Award> GetByEventId(int eventId)
        {
            var award = this.GetAwards().Where(a => a.EventId == eventId).ToList();
            return award ?? throw new EntityNotFoundException(string.Format(Messages.DoesNotExistErrorLong, "Award", "event", eventId));
        }

        public Award GetByEventIdAndRank(int eventId, int rank)
        {
            var award = this.GetAwards().FirstOrDefault(a => a.EventId == eventId && a.Rank == rank);
            return award ?? throw new EntityNotFoundException(string.Format(Messages.DoesNotExistErrorShort, "Awards", "this selection"));
        }

        public PaginatedList<Award> FilterBy(AwardQueryParameters parameters)
        {
            IQueryable<Award> awards = this.GetAwards();

            awards = this.FilterByEventId(awards, parameters.EventId);
            awards = this.FilterByEventTitle(awards, parameters.EventTitle);
            awards = this.FilterByHighestPrize(awards, parameters.PrizeUpLimit);
            awards = this.FilterByLowestPrize(awards, parameters.PrizeDownLimit);

            awards = this.SortBy(awards, parameters.SortBy);

            return Helper<Award>.Paginate(awards, parameters);
        }

        #endregion

        #region Updates
        public Award Create(Award awardToCreate)
        {
            this.context.Awards.Add(awardToCreate);
            this.context.SaveChanges();

            return this.GetByAwardId(awardToCreate.AwardId);
        }

        public void Update(Award awardToUpdate)
        {
            this.context.Update(awardToUpdate);
        }

        public void SaveDatabase()
        {
            this.context.SaveChanges();
        }
        #endregion

        #region Private IQueryable's
        private IQueryable<Award> GetAwards()
        {
            var awards = this.context.Awards.Where(a => !a.IsDeleted)
                .Include(a => a.Event);

            return awards;
        }

        private IQueryable<Award> FilterByEventId(IQueryable<Award> awards, int? eventId)
        {
            if (eventId != null)
            {
                awards = awards.Where(a => a.EventId == eventId);
            }
            return awards;
        }

        private IQueryable<Award> FilterByEventTitle(IQueryable<Award> awards, string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                awards = awards.Where(a => a.Event.Title.ToLower().Contains(title.ToLower()));
            }
            return awards;
        }

        private IQueryable<Award> FilterByHighestPrize(IQueryable<Award> awards, decimal? prizeUpLimit)
        {
            if (prizeUpLimit != null)
            {
                awards = awards.Where(a => a.Prize <= prizeUpLimit);
            }
            return awards;
        }

        private IQueryable<Award> FilterByLowestPrize(IQueryable<Award> awards, decimal? prizeDownLimit)
        {
            if (prizeDownLimit != null)
            {
                awards = awards.Where(a => a.Prize >= prizeDownLimit);
            }
            return awards;
        }

        public IQueryable<Award> SortBy(IQueryable<Award> model, string sortBy)
        {
            switch (sortBy)
            {
                case "event":
                    return model.OrderBy(a => a.Event.Title);
                case "prize":
                    return model.OrderBy(a => a.Prize);
                default:
                    return model;
            }
        }

        #endregion
    }
}
