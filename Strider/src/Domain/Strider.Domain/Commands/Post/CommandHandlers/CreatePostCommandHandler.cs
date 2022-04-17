using FluentValidation;
using Strider.Domain.Commands.Post.Commands;
using Strider.Domain.Commands.Post.Validators;
using Strider.Infrastructure.Data.Repository.PostRepository;
using Strider.Lib.Strider.Lib.Domain.Commands;
using Strider.Lib.Strider.Lib.Domain.Commands.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Strider.Domain.Commands.Post.CommandHandlers
{
    public class CreatePostCommandHandler : ICommandHandler<CreatePostCommand>
    {
        private readonly IPostRepository _postRepository;
        public CreatePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<CommandResult> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePostCommandValidators();
            validator.ValidateAndThrow(request);
            var post = new Infrastructure.Data.Model.Post(request.Text, DateTime.Now, request.UserId,
                null, null, null);
            await _postRepository.CreatedAsync(post);
            return new CommandResult(true, post);
        }
    }
}
