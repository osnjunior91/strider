using Microsoft.EntityFrameworkCore;
using Strider.Infrastructure.Data.Context;
using Strider.Infrastructure.Data.Model;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Strider.Infrastructure.Data.Repository.FollowersRepository
{
    public class FollowersRepository : IFollowersRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<Followers> _dataset;

        public async Task CreateAsync(Followers follower)
        {
            await _dataset.AddAsync(follower);
            _dataContext.SaveChangesAsync().Wait();
        }

        public async Task<Followers> FirstOrDefaultAsync(Expression<Func<Followers, bool>> filter)
        {
            return await _dataset.SingleOrDefaultAsync(filter);
        }

        public async Task UpdateAsync(Followers follower)
        {
            _dataset.Update(follower);
            await _dataContext.SaveChangesAsync();
        }
    }
}