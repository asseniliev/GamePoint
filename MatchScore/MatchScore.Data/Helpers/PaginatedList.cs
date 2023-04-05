using System.Collections.Generic;
using System.Linq;

namespace MatchScore.Data.Helpers
{
    public class PaginatedList<T> : List<T>
    {
        public PaginatedList(List<T> items, int pageSize, int currentPage)
        {
            this.AddRange(items.Skip((currentPage - 1) * pageSize).Take(pageSize));
            this.TotalPages = (items.Count + pageSize - 1) / pageSize;
            this.CurrentPage = currentPage;
        }

        public int TotalPages { get; }
        public int CurrentPage { get; }

        public bool HasPrevPage
        {
            get
            {
                return this.CurrentPage > 1;
            }
        }
        public bool HasNextPage
        {
            get
            {
                return this.CurrentPage < this.TotalPages;
            }
        }
    }

}

