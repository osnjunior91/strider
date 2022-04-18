using Strider.Domain.Queries.Followers.Queries;
using Strider.Domain.Queries.Users.Queries;
using Strider.Infrastructure.Data.Repository.FollowersRepository;
using Strider.Lib.Strider.Lib.Domain.Queries;
using Strider.Lib.Strider.Lib.Domain.Queries.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Strider.Domain.Queries.Users.QueryHandlers
{
    public class VerifyExistFollowerQueryHandler : IQueryHandler<VerifyExistFollowerQuery>
    {
        private readonly IFollowersRepository _followersRepository;
        public VerifyExistFollowerQueryHandler(IFollowersRepository followersRepository)
        {
            _followersRepository = followersRepository;
        }
        public async Task<QueryResult> Handle(VerifyExistFollowerQuery request, CancellationToken cancellationToken)
        {
            var follow = await _followersRepository.CountAsync(FollowersQueries.ExistsFollower(request.UserId, request.UserFollowId));
            return new QueryResult(true, (follow > 0));
        }
    }
}
