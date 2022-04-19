using MediatR;

namespace Strider.Lib.Strider.Lib.Domain.Commands.Interface
{
    public interface ICommandHandler<T> : IRequestHandler<T, CommandResult> where T : Command
    {
    }
}
