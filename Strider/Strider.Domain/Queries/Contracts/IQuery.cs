using MediatR;

namespace Strider.Domain.Queries.Contracts
{
    public interface IQuery : IRequest<QueryResult>
    {
    }
}
