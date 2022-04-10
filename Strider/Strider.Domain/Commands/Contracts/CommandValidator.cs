using FluentValidation;

namespace Strider.Domain.Commands.Contracts
{
    public class CommandValidator<T> : AbstractValidator<T>, ICommandValidator<T> where T : Command
    {
    }
}
