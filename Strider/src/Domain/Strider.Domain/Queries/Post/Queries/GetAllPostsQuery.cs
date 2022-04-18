using Strider.Lib.Strider.Lib.Domain.Queries;

namespace Strider.Domain.Queries.Post.Queries
{
    public class GetAllPostsQuery : Query
    {
        public GetAllPostsQuery(string text, int page, int pageSize)
        {
            Text = text;
            Page = page;
            PageSize = pageSize;
        }

        public string Text { get; private set; }
        public int Page { get; private set; }
        public int PageSize { get; private set; }
    }
}
