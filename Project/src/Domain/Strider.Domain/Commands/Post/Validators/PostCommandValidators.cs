using FluentValidation;
using Strider.Domain.Commands.Post.Commands;
using Strider.Lib.Strider.Lib.Domain.Commands;

namespace Strider.Domain.Commands.Post.Validators
{
    public abstract class PostCommandValidators<T> : CommandValidator<T> where T : CreatePostCommand
    {
        public PostCommandValidators()
        {
            RuleFor(x => x.UserId).Must(ValidGuidEmpty).WithMessage("Invalid UserId");
            RuleFor(x => x.Text)
                .NotEmpty().WithMessage("Post Text is required")
                .NotNull().WithMessage("Post Text is required")
                .MaximumLength(777).WithMessage("Posts can have a maximum of 777 characters.");
        }
    }
}
