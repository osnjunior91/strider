using MediatR;

namespace Strider.Lib.Strider.Lib.Domain.Commands.Interface
{
    public interface ICommand : IRequest<CommandResult>
    {
    }
}
