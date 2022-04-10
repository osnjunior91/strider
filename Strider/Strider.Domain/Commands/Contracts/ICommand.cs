using MediatR;

namespace Strider.Domain.Commands.Contracts
{
    public interface ICommand : IRequest<CommandResult>
    {
    }
}
