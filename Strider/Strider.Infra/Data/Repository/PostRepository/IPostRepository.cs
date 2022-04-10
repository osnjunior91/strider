using Strider.Infra.Data.Model;
using System.Threading.Tasks;

namespace Strider.Infra.Data.Repository.PostRepository
{
    public interface IPostRepository : IRepository<Post>
    {
        Task CreatedAsync(Post post);
    }
}
