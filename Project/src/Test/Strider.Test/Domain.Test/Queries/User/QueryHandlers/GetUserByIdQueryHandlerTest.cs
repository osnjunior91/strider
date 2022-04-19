using Moq;
using NUnit.Framework;
using Strider.Domain.Queries.Users.Queries;
using Strider.Domain.Queries.Users.QueryHandlers;
using Strider.Infrastructure.Data.Repository.FollowersRepository;
using Strider.Infrastructure.Data.Repository.PostRepository;
using Strider.Infrastructure.Data.Repository.UserRepository;
using Strider.Lib.Strider.Lib.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Strider.Test.Domain.Test.Queries.User.QueryHandlers
{
    public class GetUserByIdQueryHandlerTest
    {
        private Mock<IUserRepository> _userRepository;
        private Mock<IPostRepository> _postRepository;
        private Mock<IFollowersRepository> _followersRepository;
        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
            _postRepository = new Mock<IPostRepository>();
            _followersRepository = new Mock<IFollowersRepository>();
        }

        [Test]
        public async Task When_Handle_NotFound_User()
        {
            _userRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.User, bool>>>())).ReturnsAsync(value: null);
            var handle = new GetUserByIdQueryHandler(_userRepository.Object, _postRepository.Object, _followersRepository.Object);
            var response = await handle.Handle(new GetUserByIdQuery(Guid.NewGuid()), new System.Threading.CancellationToken());
            Assert.IsFalse(response.Success);
            Assert.IsTrue(response.Message.Equals("User not found"));
            Assert.That(response, Is.InstanceOf<QueryResult>());
        }

        [Test]
        public async Task When_Handle_IsOK()
        {
            var user = new Infrastructure.Data.Model.User("UserTest");

            _userRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.User, bool>>>())).ReturnsAsync(user);
            _postRepository.Setup(m => m.CountAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Post, bool>>>())).ReturnsAsync(4);
            _followersRepository.Setup(m => m.CountAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Followers, bool>>>())).ReturnsAsync(4);

            var handle = new GetUserByIdQueryHandler(_userRepository.Object, _postRepository.Object, _followersRepository.Object);
            var response = await handle.Handle(new GetUserByIdQuery(Guid.NewGuid()), new System.Threading.CancellationToken());
            Assert.IsTrue(response.Success);
            Assert.That(response, Is.InstanceOf<QueryResult>());
        }
    }
}
