using Strider.Domain.Queries.Followers.Queries;
using Strider.Domain.Queries.Post.Queries;
using Strider.Infrastructure.Data.Repository.FollowersRepository;
using Strider.Infrastructure.Data.Repository.PostRepository;
using Strider.Lib.Strider.Lib.Domain.Queries;
using Strider.Lib.Strider.Lib.Domain.Queries.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Strider.Domain.Queries.Post.QueryHandlers
{
    public class GetAllPostsOnlyFollowingQueryHandler : IQueryHandler<GetAllPostsOnlyFollowingQuery>
    {
        private readonly IPostRepository _postRepository;
        private readonly IFollowersRepository _followersRepository;
        public GetAllPostsOnlyFollowingQueryHandler(IPostRepository postRepository, IFollowersRepository followersRepository)
        {
            _postRepository = postRepository;
            _followersRepository = followersRepository;
        }
        public async Task<QueryResult> Handle(GetAllPostsOnlyFollowingQuery request, CancellationToken cancellationToken)
        {
            var following = await _followersRepository.WhereAsync(FollowersQueries.GetFollowing(request.UserId));
            var response = await _postRepository.WhereAsync(PostQueries.GetAllPostsOnlyFollowing(request.Text, following));
            return new QueryResult(true, response);
        }
    }
}
