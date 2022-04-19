using FluentValidation;
using Strider.Domain.Commands.User.Commands;
using Strider.Domain.Commands.User.Validators;
using Strider.Domain.Queries.Users.Queries;
using Strider.Infrastructure.Data.Model;
using Strider.Infrastructure.Data.Repository.FollowersRepository;
using Strider.Infrastructure.Data.Repository.UserRepository;
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
        private readonly IUserRepository _userRepository;
        public FollowCommandHandler(IFollowersRepository followersRepository, IUserRepository userRepository)
        {
            _followersRepository = followersRepository;
            _userRepository = userRepository;
        }
        public async Task<CommandResult> Handle(FollowCommand request, CancellationToken cancellationToken)
        {

            var validResult = new FollowCommandValidator().Validate(request);
            if (!validResult.IsValid)
                return new CommandResult(false, null, validResult.ToString());

            if (request.UserId == request.UserFollowId)
                return new CommandResult(false, null, "You cannot follow yourself.");
            
            var userFollow = await _userRepository.FirstOrDefaultAsync(UserQueries.GetById(request.UserFollowId));
            if (userFollow == null)
                return new CommandResult(false, null, "Invalid UserFollowId.");

            var follow = new Followers(request.UserId, request.UserFollowId);
            await _followersRepository.CreateAsync(follow);
            return new CommandResult(true, follow);
        }
    }
}
