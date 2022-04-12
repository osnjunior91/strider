using Strider.Infra.Data.Model;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Strider.Infra.Data.Repository.UserRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FirstOrDefaultAsync(Expression<Func<User, bool>> filter);
    }
}
