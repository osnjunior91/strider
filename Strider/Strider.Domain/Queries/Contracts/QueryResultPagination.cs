namespace Strider.Domain.Queries.Contracts
{
    public class QueryResultPagination: QueryResult
    {
        public int? Page { get; private set; }
        public int? PageSize { get; private set; }
        public QueryResultPagination(bool success, object data = null, int? page = null, int? pageSize = null, string message = null)
            :base(success, data, message)
        {
            Page = page;
            PageSize = pageSize;
        }

    }
}
