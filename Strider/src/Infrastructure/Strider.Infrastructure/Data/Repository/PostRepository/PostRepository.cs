using Microsoft.EntityFrameworkCore;
using Strider.Infrastructure.Data.Context;
using Strider.Infrastructure.Data.Model;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Strider.Infrastructure.Data.Repository.PostRepository
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<Post> _dataset;

        public PostRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dataset = dataContext.Set<Post>();
        }

        public async Task<int> CountAsync(Expression<Func<Post, bool>> filter)
        {
            return await _dataset.CountAsync(filter);
        }

        public async Task CreatedAsync(Post post)
        {
            await _dataset.AddAsync(post);
            _dataContext.SaveChangesAsync().Wait();
        }
    }
}
