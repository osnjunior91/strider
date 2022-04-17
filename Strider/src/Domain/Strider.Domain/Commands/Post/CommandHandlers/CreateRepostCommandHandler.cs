using FluentValidation;
using Strider.Domain.Commands.Post.Commands;
using Strider.Domain.Commands.Post.Validators;
using Strider.Domain.Queries.Post.Queries;
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

            var postDays = await _postRepository.CountAsync(PostQueries.GetPostsDay(request.UserId));
            if (postDays >= 5)
                return new CommandResult(false, null, "Not allowed to post more today. Try again tomorrow.");

            var post = new Infrastructure.Data.Model.Post(request.Text, request.UserId, null);
            await _postRepository.CreatedAsync(post);
            return new CommandResult(true, post);
        }
    }
}
