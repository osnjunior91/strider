
using FluentValidation;
using Strider.Domain.Commands.Contracts;
using Strider.Domain.Commands.Post.Commands;

namespace Strider.Domain.Commands.Post.Validators
{
    public abstract class PostCommandValidator<T> : CommandValidator<T> where T : CreatePostCommand
    {
        public PostCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull();
            RuleFor(x => x.Text).NotEmpty().NotNull();
        }
    }
}
