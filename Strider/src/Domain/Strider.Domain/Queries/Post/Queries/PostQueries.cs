using System;
using System.Linq.Expressions;

namespace Strider.Domain.Queries.Post.Queries
{
    public static class PostQueries
    {
        public static Expression<Func<Infrastructure.Data.Model.Post, bool>> GetPostsDay(Guid userId)
        {
            return x => x.UserId == userId && (x.CreatedAt > DateTime.Today.Date.AddMilliseconds(-1) && x.CreatedAt < DateTime.Today.Date.AddDays(1).AddMilliseconds(-1));
        }
    }
}
