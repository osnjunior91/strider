using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Strider.Domain.Queries.Followers.Queries
{
    public static class FollowersQueries
    {
        public static Expression<Func<Infrastructure.Data.Model.Followers, bool>> ExistsFollower(Guid userId, Guid followerId)
        {
            return x => x.UserId == userId && x.FollowerId == followerId;
        }
    }
}
