using Moq;
using NUnit.Framework;
using Strider.Domain.Queries.Users.Queries;
using Strider.Domain.Queries.Users.QueryHandlers;
using Strider.Infrastructure.Data.Repository.FollowersRepository;
using Strider.Lib.Strider.Lib.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Strider.Test.Domain.Test.Queries.User.QueryHandlers
{
    public class VerifyExistFollowerQueryHandlerTest
    {
        private Mock<IFollowersRepository> _followersRepository;

        [SetUp]
        public void Setup() 
        {
            _followersRepository = new Mock<IFollowersRepository>();
        }

        [TestCase(0, false)]
        [TestCase(1, true)]
        public async Task Handle_Follow(int follows, bool expectReturn)
        {
            _followersRepository.Setup(m => m.CountAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Followers, bool>>>())).ReturnsAsync(follows);
            var handle = new VerifyExistFollowerQueryHandler(_followersRepository.Object);
            var response = await handle.Handle(new VerifyExistFollowerQuery(Guid.NewGuid(), Guid.NewGuid()), new System.Threading.CancellationToken());
            Assert.AreEqual((bool)response.Data, expectReturn);
            Assert.That(response, Is.InstanceOf<QueryResult>());
        }
    }
}
