using Strider.Domain.Queries.Contracts;
using Strider.Domain.Queries.Users.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace Strider.Domain.Queries.Users.QueryHandlers
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery>
    {
        public Task<QueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
