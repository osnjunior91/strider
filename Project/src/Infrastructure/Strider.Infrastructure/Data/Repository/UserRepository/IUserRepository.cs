using Strider.Infrastructure.Data.Model;
using Strider.Lib.Strider.Lib.Infrastructure.Data.Repository;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Strider.Infrastructure.Data.Repository.UserRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FirstOrDefaultAsync(Expression<Func<User, bool>> filter);
    }
}
