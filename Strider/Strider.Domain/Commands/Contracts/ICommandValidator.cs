using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strider.Domain.Commands.Contracts
{
    public interface ICommandValidator<T> : IRequest<T> where T : ICommand
    {
    }
}
