namespace Strider.Domain.Queries.Contracts
{
    public abstract class QueryPagination : Query
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
