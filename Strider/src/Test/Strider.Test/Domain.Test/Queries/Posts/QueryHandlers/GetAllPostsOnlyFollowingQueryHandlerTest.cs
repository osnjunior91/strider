using Moq;
using NUnit.Framework;
using Strider.Domain.Queries.Post.Queries;
using Strider.Domain.Queries.Post.QueryHandlers;
using Strider.Infrastructure.Data.Repository.FollowersRepository;
using Strider.Infrastructure.Data.Repository.PostRepository;
using Strider.Lib.Strider.Lib.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Strider.Test.Domain.Test.Queries.Posts.QueryHandlers
{
    public class GetAllPostsOnlyFollowingQueryHandlerTest
    {
        private Mock<IPostRepository> _postRepository;
        private Mock<IFollowersRepository> _followersRepository;
        [SetUp]
        public void Setup()
        {
            _postRepository = new Mock<IPostRepository>();
            _followersRepository = new Mock<IFollowersRepository>();
        }
        [Test]
        public async Task When_Handle_NotFound_Follow()
        {
            _followersRepository.Setup(m => m.WhereAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Followers, bool>>>())).ReturnsAsync(new List<Infrastructure.Data.Model.Followers>());
            var handle = new GetAllPostsOnlyFollowingQueryHandler(_postRepository.Object, _followersRepository.Object);
            var response = await handle.Handle(new GetAllPostsOnlyFollowingQuery(Guid.NewGuid(), "", 0, 0), new System.Threading.CancellationToken());
            Assert.IsTrue(response.Success);
            Assert.That(response, Is.InstanceOf<QueryResult>());
            var responseData = (IEnumerable<object>)response.Data;
            Assert.IsTrue(responseData.Count() == 0);
        }

        [Test]
        public async Task When_Handle_Found_Follow()
        {
            _followersRepository.Setup(m => m.WhereAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Followers, bool>>>())).ReturnsAsync(new List<Infrastructure.Data.Model.Followers>() { new Infrastructure.Data.Model.Followers() });
            _postRepository.Setup(m => m.WhereAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Post, bool>>>(), It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(new List<Infrastructure.Data.Model.Post>() 
                { 
                    new Infrastructure.Data.Model.Post("Text", Guid.NewGuid(), null, null, null) 
                });
            var handle = new GetAllPostsOnlyFollowingQueryHandler(_postRepository.Object, _followersRepository.Object);
            var response = await handle.Handle(new GetAllPostsOnlyFollowingQuery(Guid.NewGuid(), "", 0, 0), new System.Threading.CancellationToken());
            Assert.IsTrue(response.Success);
            Assert.That(response, Is.InstanceOf<QueryResult>());
            var responseData = (IEnumerable<object>)response.Data;
            Assert.IsTrue(responseData.Count() == 1);
        }
    }
}
