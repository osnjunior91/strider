using Strider.Domain.Queries.Post.Queries;
using Strider.Infrastructure.Data.Repository.PostRepository;
using Strider.Lib.Strider.Lib.Domain.Queries;
using Strider.Lib.Strider.Lib.Domain.Queries.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Strider.Domain.Queries.Post.QueryHandlers
{
    public class GetAllPostsQueryHandler : IQueryHandler<GetAllPostsQuery>
    {
        private readonly IPostRepository _postRepository;
        public GetAllPostsQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<QueryResult> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var response = await _postRepository.WhereAsync(PostQueries.GetAllPosts());
            return new QueryResult(true, response);
        }
    }
}
