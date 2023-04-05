namespace MatchScore.Data.Models.QueryParameters
{
    public abstract class QueryParameters
    {
        public string SortBy { get; set; }

        public string SortOrder { get; set; }

        public string PaginationSortOrder { get; set; }

        public bool IsHeader { get; set; }

        public int CurrentPage { get; set; } = 1;

        public virtual int PageSize { get; set; } = 10;
    }
}
