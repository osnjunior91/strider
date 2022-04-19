using Moq;
using NUnit.Framework;
using Strider.Domain.Queries.Post.Queries;
using Strider.Domain.Queries.Post.QueryHandlers;
using Strider.Infrastructure.Data.Repository.PostRepository;
using Strider.Lib.Strider.Lib.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Strider.Test.Domain.Test.Queries.Posts.QueryHandlers
{
    public class GetUserLastPostsQueryHandlerTest
    {
        private Mock<IPostRepository> _postRepository;
        [SetUp]
        public void Setup()
        {
            _postRepository = new Mock<IPostRepository>();
            _postRepository.Setup(m => m.WhereAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Post, bool>>>(), It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(new List<Infrastructure.Data.Model.Post>()
                {
                    new Infrastructure.Data.Model.Post("Text", Guid.NewGuid(), null, null, null)
                });
        }

        [Test]
        public async Task When_Handle_IsOk()
        {
            var handle = new GetUserLastPostsQueryHandler(_postRepository.Object);
            var response = await handle.Handle(new GetUserLastPostsQuery(Guid.NewGuid(), 0, 0), new System.Threading.CancellationToken());
            Assert.IsTrue(response.Success);
            Assert.That(response, Is.InstanceOf<QueryResult>());
        }
    }
}
