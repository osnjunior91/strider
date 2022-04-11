using Strider.Infra.Data.Model;
using System.Threading.Tasks;

namespace Strider.Infra.Data.Repository.PostRepository
{
    public interface IFollowersRepository : IRepository<Followers>
    {
        Task CreatedAsync(Followers follower);
    }
}
