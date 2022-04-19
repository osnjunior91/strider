using Strider.Lib.Strider.Lib.Domain.Queries;
using System;

namespace Strider.Domain.Queries.Post.Queries
{
    public class GetUserLastPostsQuery : QueryPagination
    {
        public GetUserLastPostsQuery(Guid userId, int page, int pageSize) : base(page, pageSize)
        {
            UserId = userId;
        }
        public Guid UserId { get; private set; }
    }
}
