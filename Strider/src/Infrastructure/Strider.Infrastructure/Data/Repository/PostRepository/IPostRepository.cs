using Strider.Infrastructure.Data.Model;
using Strider.Lib.Strider.Lib.Infrastructure.Data.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Strider.Infrastructure.Data.Repository.PostRepository
{
    public interface IPostRepository : IRepository<Post>
    {
        Task CreatedAsync(Post post);
        Task<int> CountAsync(Expression<Func<Post, bool>> filter);
        Task<Post> FirstOrDefaultAsync(Expression<Func<Post, bool>> filter);
        Task<List<Post>> WhereAsync(Expression<Func<Post, bool>> filter);
    }
}
