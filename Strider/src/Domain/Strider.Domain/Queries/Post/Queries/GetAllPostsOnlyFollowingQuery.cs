using System;

namespace Strider.Domain.Queries.Post.Queries
{
    public class GetAllPostsOnlyFollowingQuery : GetAllPostsQuery
    {
        public GetAllPostsOnlyFollowingQuery(Guid userId, string text) : base(text)
        {
            UserId = userId;
        }
        public Guid UserId { get; private set; }
    }
}
