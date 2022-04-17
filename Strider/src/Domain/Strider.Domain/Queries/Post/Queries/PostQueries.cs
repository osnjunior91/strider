using System;
using System.Linq.Expressions;

namespace Strider.Domain.Queries.Post.Queries
{
    public static class PostQueries
    {
        public static Expression<Func<Infrastructure.Data.Model.Post, bool>> GetPostsDay(Guid userId)
        {
            return x => x.UserId == userId && (x.CreatedAt >= DateTime.Today.Date && x.CreatedAt < DateTime.Today.Date.AddDays(1));
        }

        public static Expression<Func<Infrastructure.Data.Model.Post, bool>> GetAllPostsByText(string text)
        {
            return (text?.Length > 0)
               ? x => x.Text.ToLower().Contains(text.ToLower()) && x.IsDelete == false
               : x => x.IsDelete == false;
        }
    }
}
