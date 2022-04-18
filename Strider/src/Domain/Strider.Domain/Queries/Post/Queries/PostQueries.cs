using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Strider.Domain.Queries.Post.Queries
{
    public static class PostQueries
    {
        public static Expression<Func<Infrastructure.Data.Model.Post, bool>> GetPostsDay(Guid userId)
        {
            return x => x.UserId == userId && (x.CreatedAt >= DateTime.Today.Date && x.CreatedAt < DateTime.Today.Date.AddDays(1)) && x.IsDelete == false;
        }

        public static Expression<Func<Infrastructure.Data.Model.Post, bool>> GetById(Guid id)
        {
            return x => x.Id == id && x.IsDelete == false;
        }

        public static Expression<Func<Infrastructure.Data.Model.Post, bool>> GetUserLastPost(Guid userId)
        {
            return x => x.UserId == userId && x.IsDelete == false;
        }

        public static Expression<Func<Infrastructure.Data.Model.Post, bool>> GetAllPostsByText(string text)
        {
            return (text?.Length > 0)
               ? x => x.Text.ToLower().Contains(text.ToLower()) && x.IsDelete == false
               : x => x.IsDelete == false;
        }
        public static Expression<Func<Infrastructure.Data.Model.Post, bool>> GetAllPostsOnlyFollowing(string text, List<Infrastructure.Data.Model.Followers> users)
        {

            var filter = PredicateBuilder.New<Infrastructure.Data.Model.Post>(true);
            var filterFollowing = PredicateBuilder.New<Infrastructure.Data.Model.Post>(true);

            if (text?.Length > 0)
                filter = filter.Start(x => (x.Text.ToLower().Contains(text.ToLower()) && x.IsDelete == false));
            else
                filter.Start(x => (x.IsDelete == false));

            foreach (var item in users)
            {
                filterFollowing = filterFollowing.Or(x => x.UserId == item.FollowerId);
            }

            filter = filter.And(filterFollowing);
            return filterFollowing;
        }
    }
}
