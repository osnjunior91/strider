using Strider.Infrastructure.Data.Model;
using Strider.Lib.Strider.Lib.Infrastructure.Data.Repository;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Strider.Infrastructure.Data.Repository.FollowersRepository
{
    public interface IFollowersRepository : IRepository<Followers>
    {
        Task CreateAsync(Followers follower);
        Task<Followers> FirstOrDefaultAsync(Expression<Func<Followers, bool>> filter);
        Task DeleteAsync(Followers follower);
    }
}
