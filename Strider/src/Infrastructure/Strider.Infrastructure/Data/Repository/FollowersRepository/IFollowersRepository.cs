using Strider.Infrastructure.Data.Model;
using Strider.Lib.Strider.Lib.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Strider.Infrastructure.Data.Repository.FollowersRepository
{
    public interface IFollowersRepository : IRepository<Followers>
    {
        Task CreateAsync(Followers follower);
        Task<Followers> FirstOrDefaultAsync(Expression<Func<Followers, bool>> filter);
        Task<int> CountAsync(Expression<Func<Followers, bool>> filter);
        Task<List<Followers>> WhereAsync(Expression<Func<Followers, bool>> filter);
        Task UpdateAsync(Followers follower);
    }
}
