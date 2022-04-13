using FluentValidation;
using Strider.Domain.Commands.Contracts;
using Strider.Domain.Commands.User.Commands;

namespace Strider.Domain.Commands.User.Validators
{
    public class FollowCommandValidator : FollowBaseCommandValidator<FollowCommand>
    {
    }
}
