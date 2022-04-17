using Strider.Lib.Strider.Lib.Domain.Queries;

namespace Strider.Domain.Queries.Post.Queries
{
    public class GetAllPostsQuery : Query
    {
        public GetAllPostsQuery(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }
    }
}
