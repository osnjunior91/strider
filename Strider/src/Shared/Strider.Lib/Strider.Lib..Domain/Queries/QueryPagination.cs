namespace Strider.Lib.Strider.Lib.Domain.Queries
{
    public abstract class QueryPagination : Query 
    {
        protected QueryPagination(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; private set; }
        public int PageSize { get; private set; }
    }
}
