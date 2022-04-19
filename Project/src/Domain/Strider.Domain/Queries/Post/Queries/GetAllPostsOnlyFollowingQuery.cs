using System;

namespace Strider.Domain.Queries.Post.Queries
{
    public class GetAllPostsOnlyFollowingQuery : GetAllPostsQuery
    {
        public GetAllPostsOnlyFollowingQuery(Guid userId, string text, int page, int pageSize) : base(text, page, pageSize)
        {
            UserId = userId;
        }
        public Guid UserId { get; private set; }
    }
}
