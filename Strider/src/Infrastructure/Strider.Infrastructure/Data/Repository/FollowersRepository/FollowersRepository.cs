using Microsoft.EntityFrameworkCore;
using Strider.Infrastructure.Data.Context;
using Strider.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Strider.Infrastructure.Data.Repository.FollowersRepository
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

        public async Task<int> CountAsync(Expression<Func<Followers, bool>> filter)
        {
            return await _dataset.CountAsync(filter);
        }

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

        public async Task<List<Followers>> WhereAsync(Expression<Func<Followers, bool>> filter)
        {
            return await _dataset.AsQueryable().Where(filter).ToListAsync();
        }
    }
}