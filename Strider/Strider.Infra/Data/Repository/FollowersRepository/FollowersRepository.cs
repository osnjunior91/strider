using Microsoft.EntityFrameworkCore;
using Strider.Infra.Data.Context;
using Strider.Infra.Data.Model;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Strider.Infra.Data.Repository.FollowersRepository
{
    public class FollowersRepository : IFollowersRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<Followers> _dataset;

        public FollowersRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dataset = dataContext.Set<Followers>();
        }
        public async Task CreatedAsync(Followers follower)
        {
            await _dataset.AddAsync(follower);
            _dataContext.SaveChangesAsync().Wait();
        }

        public async Task DeleteAsync(Followers follower)
        {
            _dataset.Remove(follower);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Followers> FirstOrDefaultAsync(Expression<Func<Followers, bool>> filter)
        {
            return await _dataset.SingleOrDefaultAsync(filter);
        }
    }
}
