using FluentValidation;
using Strider.Domain.Commands.Post.Commands;


namespace Strider.Domain.Commands.Post.Validators
{
    public class CreateRepostCommandValidators : PostCommandValidators<CreateRepostCommand>
    {
        public CreateRepostCommandValidators() : base()
        {
            RuleFor(x => x.RepostedFromId).NotEmpty().NotNull();
        }
    }
}
