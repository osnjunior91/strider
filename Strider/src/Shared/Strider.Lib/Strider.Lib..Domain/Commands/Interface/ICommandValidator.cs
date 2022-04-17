using MediatR;

namespace Strider.Lib.Strider.Lib.Domain.Commands.Interface
{
    public interface ICommandValidator<T> : IRequest<T> where T : ICommand
    {
    }
}
