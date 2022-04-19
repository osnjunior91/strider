using Strider.Lib.Strider.Lib.Domain.Queries;
using System;

namespace Strider.Domain.Queries.Users.Queries
{
    public class GetUserByIdQuery : Query
    {
        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
