using FluentValidation;
using Strider.Domain.Commands.User.Commands;
using Strider.Lib.Strider.Lib.Domain.Commands;

namespace Strider.Domain.Commands.User.Validators
{
    public class FollowBaseCommandValidator<T> : CommandValidator<T> where T : FollowCommand
    {
        public FollowBaseCommandValidator()
        {
            RuleFor(x => x.UserId).Must(ValidGuidEmpty).WithMessage("Invalid UserId");
            RuleFor(x => x.UserFollowId).Must(ValidGuidEmpty).WithMessage("Invalid UserFollowId");
        }
    }
}
