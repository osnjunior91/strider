using Strider.Domain.Queries.Followers.Queries;
using Strider.Domain.Queries.Post.Queries;
using Strider.Domain.Queries.Users.Queries;
using Strider.Domain.Queries.Users.ViewModels;
using Strider.Infrastructure.Data.Repository.FollowersRepository;
using Strider.Infrastructure.Data.Repository.PostRepository;
using Strider.Infrastructure.Data.Repository.UserRepository;
using Strider.Lib.Strider.Lib.Domain.Queries;
using Strider.Lib.Strider.Lib.Domain.Queries.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Strider.Domain.Queries.Users.QueryHandlers
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly IFollowersRepository _followersRepository;
        public GetUserByIdQueryHandler(IUserRepository userRepository, IPostRepository postRepository, 
            IFollowersRepository followersRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _followersRepository = followersRepository;
        }
        public async Task<QueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FirstOrDefaultAsync(UserQueries.GetById(request.Id));
            if (user == null)
                return new QueryResult(false, null, "User not found");
            var postsToday = await _postRepository.CountAsync(PostQueries.GetPostsDay(request.Id));
            var followers = await _followersRepository.CountAsync(FollowersQueries.GetFollower(request.Id));
            var following = await _followersRepository.CountAsync(FollowersQueries.GetFollowing(request.Id));
            return new QueryResult(true, new UserViewModel(user.Username, user.Joined, followers, following, postsToday));
        }
    }
}
