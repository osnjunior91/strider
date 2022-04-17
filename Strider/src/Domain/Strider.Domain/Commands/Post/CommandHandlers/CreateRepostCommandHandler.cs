using FluentValidation;
using Strider.Domain.Commands.Post.Commands;
using Strider.Domain.Commands.Post.Validators;
using Strider.Infrastructure.Data.Repository.PostRepository;
using Strider.Lib.Strider.Lib.Domain.Commands;
using Strider.Lib.Strider.Lib.Domain.Commands.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Strider.Domain.Commands.Post.CommandHandlers
{
    public class CreateRepostCommandHandler : ICommandHandler<CreateRepostCommand>
    {
        private readonly IPostRepository _postRepository;
        public CreateRepostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<CommandResult> Handle(CreateRepostCommand request, CancellationToken cancellationToken)
        {
            var validResult = new CreateRepostCommandValidators().Validate(request);
            if (!validResult.IsValid)
                return new CommandResult(false, null, validResult.ToString());
            var post = new Infrastructure.Data.Model.Post(request.Text, DateTime.Now, request.UserId,
                null, request.RepostedFromId, null);
            await _postRepository.CreatedAsync(post);
            return new CommandResult(true, post);
        }
    }
}
