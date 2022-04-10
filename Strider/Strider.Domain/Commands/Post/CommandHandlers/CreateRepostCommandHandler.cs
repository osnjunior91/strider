using FluentValidation;
using Strider.Domain.Commands.Contracts;
using Strider.Domain.Commands.Post.Commands;
using Strider.Domain.Commands.Post.Validators;
using Strider.Infra.Data.Repository.PostRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var validator = new CreateRepostCommandValidators();
            validator.ValidateAndThrow(request);
            var post = new Infra.Data.Model.Post(request.Text, DateTime.Now, request.UserId,
                null, request.RepostedFromId, null);
            await _postRepository.CreatedAsync(post);
            return new CommandResult(true, post);
        }
    }
}
