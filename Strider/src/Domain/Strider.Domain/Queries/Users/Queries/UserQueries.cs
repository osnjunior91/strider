using Strider.Infrastructure.Data.Model;
using System;
using System.Linq.Expressions;

namespace Strider.Domain.Queries.Users.Queries
{
    public static class UserQueries
    {
        public static Expression<Func<User, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
