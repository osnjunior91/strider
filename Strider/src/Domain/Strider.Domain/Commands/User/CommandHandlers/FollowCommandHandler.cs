using FluentValidation;
using Strider.Domain.Commands.User.Commands;
using Strider.Domain.Commands.User.Validators;
using Strider.Infrastructure.Data.Model;
using Strider.Infrastructure.Data.Repository.FollowersRepository;
using Strider.Lib.Strider.Lib.Domain.Commands;
using Strider.Lib.Strider.Lib.Domain.Commands.Interface;
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
            if (request.UserId == request.UserFollowId)
                throw new ArgumentException("You cannot follow yourself.");
            var follow = new Followers(request.UserId, request.UserFollowId);
            await _followersRepository.CreateAsync(follow);
            return new CommandResult(true, follow);
        }
    }
}
