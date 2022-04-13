using System;
using System.Linq.Expressions;

namespace Strider.Domain.Queries.Followers.Queries
{
    public static class FollowersQueries
    {
        public static Expression<Func<Infra.Data.Model.Followers, bool>> ExistsFollower(Guid userId, Guid followerId)
        {
            return x => x.UserId == userId && x.FollowerId == followerId;
        }
    }
}
