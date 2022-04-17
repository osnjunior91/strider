using FluentValidation;
using Strider.Domain.Commands.Post.Commands;
using Strider.Lib.Strider.Lib.Domain.Commands;

namespace Strider.Domain.Commands.Post.Validators
{
    public abstract class PostCommandValidators<T> : CommandValidator<T> where T : CreatePostCommand
    {
        public PostCommandValidators()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull();
            RuleFor(x => x.Text).NotEmpty().NotNull();
        }
    }
}
