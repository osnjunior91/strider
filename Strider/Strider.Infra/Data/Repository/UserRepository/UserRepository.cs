using Microsoft.EntityFrameworkCore;
using Strider.Infra.Data.Context;
using Strider.Infra.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Strider.Infra.Data.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<User> _dataset;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dataset = _dataContext.Set<User>();
        }
        public async Task<User> FirstOrDefaultAsync(Expression<Func<User, bool>> filter)
        {
            return await _dataset.SingleOrDefaultAsync(filter);
        }
    }
}
