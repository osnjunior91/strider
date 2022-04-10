using Microsoft.EntityFrameworkCore;
using Strider.Infra.Data.Context;
using Strider.Infra.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strider.Infra.Data.Repository.PostRepository
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

        public async Task CreatedAsync(Post post)
        {
            await _dataset.AddAsync(post);
            _dataContext.SaveChangesAsync().Wait();
        }
    }
}
