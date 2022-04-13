using FluentValidation;
using Strider.Domain.Commands.Contracts;
using Strider.Domain.Commands.User.Commands;
using Strider.Domain.Commands.User.Validators;
using Strider.Domain.Queries.Followers.Queries;
using Strider.Infra.Data.Repository.FollowersRepository;
using System.Threading;
using System.Threading.Tasks;

namespace Strider.Domain.Commands.User.CommandHandlers
{
    public class UnfollowCommandHandler : ICommandHandler<UnfollowCommand>
    {
        private readonly IFollowersRepository _followersRepository;
        public UnfollowCommandHandler(IFollowersRepository followersRepository)
        {
            _followersRepository = followersRepository;
        }
        public async Task<CommandResult> Handle(UnfollowCommand request, CancellationToken cancellationToken)
        {
            var validator = new UnfollowCommandValidator();
            validator.ValidateAndThrow(request);
            var follow = await _followersRepository.FirstOrDefaultAsync(FollowersQueries.ExistsFollower(request.UserId, request.UserFollowId));
            if(follow == null)
                return new CommandResult(false, null, "Not Found");
            await _followersRepository.DeleteAsync(follow);
            return new CommandResult(true, null, "Delete success");
        }
    }
}
