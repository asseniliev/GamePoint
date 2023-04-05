using MatchScore.Data.Models.QueryParameters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchScore.Data.Helpers
{
    public class Helper<T>
    {
        private static List<T> SortOrder(IQueryable<T> model, string sortOrder)
        {
            switch (sortOrder)
            {
                case "desc":
                    return model.AsQueryable<T>().Reverse<T>().ToList();
                default:
                    return model.ToList();
            }
        }

        public static PaginatedList<T> Paginate(IQueryable<T> model, QueryParameters parameters)
        {
            var result = SortOrder(model, parameters.SortOrder);
            return new PaginatedList<T>(result, parameters.PageSize, parameters.CurrentPage);
        }
    }
}
