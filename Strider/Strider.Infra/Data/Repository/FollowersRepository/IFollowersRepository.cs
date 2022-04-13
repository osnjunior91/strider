using Strider.Infra.Data.Model;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Strider.Infra.Data.Repository.FollowersRepository
{
    public interface IFollowersRepository : IRepository<Followers>
    {
        Task CreatedAsync(Followers follower);
        Task<Followers> FirstOrDefaultAsync(Expression<Func<Followers, bool>> filter);
        Task DeleteAsync(Followers follower);
    }
}
