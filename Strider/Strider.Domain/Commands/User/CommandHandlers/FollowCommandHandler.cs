using FluentValidation;
using Strider.Domain.Commands.Contracts;
using Strider.Domain.Commands.User.Commands;
using Strider.Domain.Commands.User.Validators;
using Strider.Infra.Data.Model;
using Strider.Infra.Data.Repository.FollowersRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Strider.Domain.Commands.User.CommandHandlers
{
    public class FollowCommandHandler : ICommandHandler<FollowCommand>
    {
        private readonly IFollowersRepository _followersRepository;
        public FollowCommandHandler(IFollowersRepository followersRepository)
        {
            _followersRepository = followersRepository;
        }
        public async Task<CommandResult> Handle(FollowCommand request, CancellationToken cancellationToken)
        {
            var validator = new FollowCommandValidator();
            validator.ValidateAndThrow(request);
            var follow = new Followers(request.UserId, request.UserFollowId);
            await _followersRepository.CreatedAsync(follow);
            return new CommandResult(true, follow);
        }
    }
}
