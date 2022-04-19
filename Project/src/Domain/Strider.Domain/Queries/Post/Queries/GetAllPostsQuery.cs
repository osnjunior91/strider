using Strider.Lib.Strider.Lib.Domain.Queries;

namespace Strider.Domain.Queries.Post.Queries
{
    public class GetAllPostsQuery : QueryPagination
    {
        public GetAllPostsQuery(string text, int page, int pageSize) : base(page, pageSize)
        {
            Text = text;
        }

        public string Text { get; private set; }
    }
}
