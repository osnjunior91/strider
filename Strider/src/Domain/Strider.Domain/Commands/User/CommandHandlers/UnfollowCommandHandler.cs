using FluentValidation;
using Strider.Domain.Commands.User.Commands;
using Strider.Domain.Commands.User.Validators;
using Strider.Domain.Queries.Followers.Queries;
using Strider.Infrastructure.Data.Repository.FollowersRepository;
using Strider.Lib.Strider.Lib.Domain.Commands;
using Strider.Lib.Strider.Lib.Domain.Commands.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            if (follow == null)
                return new CommandResult(false, null, "Not Found");
            //TODO Mudar delete para nao perder dados await _followersRepository.DeleteAsync(follow);
            return new CommandResult(true, null, "Delete success");
        }
    }
}
