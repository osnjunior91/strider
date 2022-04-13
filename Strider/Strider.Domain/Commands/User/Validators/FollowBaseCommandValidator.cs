using FluentValidation;
using Strider.Domain.Commands.Contracts;
using Strider.Domain.Commands.User.Commands;

namespace Strider.Domain.Commands.User.Validators
{
    public class FollowBaseCommandValidator<T> : CommandValidator<T> where T : FollowCommand
    {
        public FollowBaseCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull();
            RuleFor(x => x.UserFollowId).NotEmpty().NotNull();
        }
    }
}
