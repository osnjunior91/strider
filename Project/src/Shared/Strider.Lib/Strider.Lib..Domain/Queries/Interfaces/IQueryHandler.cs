using MediatR;

namespace Strider.Lib.Strider.Lib.Domain.Queries.Interfaces
{
    public interface IQueryHandler<T> : IRequestHandler<T, QueryResult> where T : Query
    {
    }
}
