using FluentValidation;
using Strider.Lib.Strider.Lib.Domain.Commands.Interface;
using System;

namespace Strider.Lib.Strider.Lib.Domain.Commands
{
    public class CommandValidator<T> : AbstractValidator<T>, ICommandValidator<T> where T : Command
    {
        protected bool ValidGuidEmpty(Guid guid)
        {
            return guid != Guid.Empty;
        }
    }
}
