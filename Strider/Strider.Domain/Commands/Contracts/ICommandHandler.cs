using MediatR;

namespace Strider.Domain.Commands.Contracts
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, CommandResult> where TCommand : Command
    {
    }
}
