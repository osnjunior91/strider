using Moq;
using NUnit.Framework;
using Strider.Domain.Commands.User.CommandHandlers;
using Strider.Domain.Commands.User.Commands;
using Strider.Infrastructure.Data.Repository.FollowersRepository;
using Strider.Lib.Strider.Lib.Domain.Commands;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Strider.Test.Domain.Test.Commands.User.CommandHandlers
{
    public class UnfollowCommandHandlerTest
    {
        private Mock<IFollowersRepository> _followersRepository;

        [SetUp]
        public void Setup()
        {
            _followersRepository = new Mock<IFollowersRepository>();
        }

        [TestCase("127f0c34-d774-44d4-8d9e-d3c3df8af908", "00000000-0000-0000-0000-000000000000")]
        [TestCase("00000000-0000-0000-0000-000000000000", "127f0c34-d774-44d4-8d9e-d3c3df8af908")]
        public async Task When_Handle_Invalid_Params(Guid userId, Guid userFollowId)
        {
            var handle = new UnfollowCommandHandler(_followersRepository.Object);
            var response = await handle.Handle(new UnfollowCommand(userId, userFollowId), new System.Threading.CancellationToken());
            Assert.That(response, Is.InstanceOf<CommandResult>());
            Assert.IsFalse(response.Success);
        }
        [Test]
        public async Task When_Handle_Follow_NotFound()
        {

            _followersRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Followers, bool>>>())).ReturnsAsync(value: null);
            var handle = new UnfollowCommandHandler(_followersRepository.Object);
            var response = await handle.Handle(new UnfollowCommand(Guid.NewGuid(), Guid.NewGuid()), new System.Threading.CancellationToken());
            Assert.That(response, Is.InstanceOf<CommandResult>());
            Assert.IsFalse(response.Success);
            Assert.IsTrue(response.Message.Equals("Not Found"));
        }

        [Test]
        public async Task When_Handle_IsOk()
        {

            _followersRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Followers, bool>>>())).ReturnsAsync(new Infrastructure.Data.Model.Followers(Guid.NewGuid(), Guid.NewGuid()));
            var handle = new UnfollowCommandHandler(_followersRepository.Object);
            var response = await handle.Handle(new UnfollowCommand(Guid.NewGuid(), Guid.NewGuid()), new System.Threading.CancellationToken());
            Assert.That(response, Is.InstanceOf<CommandResult>());
            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.Message.Equals("Unfollow success"));
        }
    }
}
