using MediatR;

namespace Strider.Domain.Queries.Contracts
{
    public interface IQueryHandler<TQuery> : IRequestHandler<TQuery, QueryResult> where TQuery : Query
    {
    }
}
