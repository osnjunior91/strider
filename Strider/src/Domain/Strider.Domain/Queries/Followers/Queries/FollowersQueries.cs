using System;
using System.Linq.Expressions;

namespace Strider.Domain.Queries.Followers.Queries
{
    public static class FollowersQueries
    {
        public static Expression<Func<Infrastructure.Data.Model.Followers, bool>> ExistsFollower(Guid userId, Guid followerId)
        {
            return x => x.UserId == userId && x.FollowerId == followerId && x.IsDelete == false;
        }

        public static Expression<Func<Infrastructure.Data.Model.Followers, bool>> GetFollower(Guid userId)
        {
            return x => x.FollowerId == userId && x.IsDelete == false;
        }

        public static Expression<Func<Infrastructure.Data.Model.Followers, bool>> GetFollowing(Guid userId)
        {
            return x => x.UserId == userId && x.IsDelete == false;
        }
    }
}
