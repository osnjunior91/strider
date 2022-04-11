using FluentValidation;
using Strider.Domain.Commands.Contracts;
using Strider.Domain.Commands.User.Commands;

namespace Strider.Domain.Commands.User.Validators
{
    public class FollowCommandValidator : CommandValidator<FollowCommand>
    {
        public FollowCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull();
            RuleFor(x => x.UserFollowId).NotEmpty().NotNull();
        }
    }
}
