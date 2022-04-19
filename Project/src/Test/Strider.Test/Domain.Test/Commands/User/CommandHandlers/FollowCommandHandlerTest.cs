using Moq;
using NUnit.Framework;
using Strider.Domain.Commands.User.CommandHandlers;
using Strider.Domain.Commands.User.Commands;
using Strider.Infrastructure.Data.Model;
using Strider.Infrastructure.Data.Repository.FollowersRepository;
using Strider.Infrastructure.Data.Repository.UserRepository;
using Strider.Lib.Strider.Lib.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Strider.Test.Domain.Test.Commands.User.CommandHandlers
{
    public class FollowCommandHandlerTest
    {
        private Mock<IFollowersRepository> _followersRepository;
        private Mock<IUserRepository> _userRepository;
        [SetUp]
        public void Setup()
        {
            _followersRepository = new Mock<IFollowersRepository>();
            _userRepository = new Mock<IUserRepository>();
        }

        [TestCase("127f0c34-d774-44d4-8d9e-d3c3df8af908", "00000000-0000-0000-0000-000000000000")]
        [TestCase("00000000-0000-0000-0000-000000000000", "127f0c34-d774-44d4-8d9e-d3c3df8af908")]
        [TestCase("127f0c34-d774-44d4-8d9e-d3c3df8af908", "127f0c34-d774-44d4-8d9e-d3c3df8af908")]
        public async Task When_Handle_Invalid_Params(Guid userId, Guid userFollowId)
        {
            var handle = new FollowCommandHandler(_followersRepository.Object, _userRepository.Object);
            var response = await handle.Handle(new FollowCommand(userId, userFollowId), new System.Threading.CancellationToken());
            Assert.That(response, Is.InstanceOf<CommandResult>());
            Assert.IsFalse(response.Success);
        }

        [Test]
        public async Task When_Handle_User_NotFound()
        {
            _userRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.User, bool>>>())).ReturnsAsync(value: null);
            var handle = new FollowCommandHandler(_followersRepository.Object, _userRepository.Object);
            var response = await handle.Handle(new FollowCommand(Guid.NewGuid(), Guid.NewGuid()), new System.Threading.CancellationToken());
            Assert.That(response, Is.InstanceOf<CommandResult>());
            Assert.IsFalse(response.Success);
            Assert.IsTrue(response.Message.Equals("Invalid UserFollowId."));
        }

        [Test]
        public async Task When_Handle_IsOk()
        {
            _userRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.User, bool>>>())).ReturnsAsync(new Infrastructure.Data.Model.User("name"));
            _followersRepository.Setup(m => m.CreateAsync(It.IsAny<Followers>())).Verifiable();
            var handle = new FollowCommandHandler(_followersRepository.Object, _userRepository.Object);
            var response = await handle.Handle(new FollowCommand(Guid.NewGuid(), Guid.NewGuid()), new System.Threading.CancellationToken());
            Assert.That(response, Is.InstanceOf<CommandResult>());
            Assert.IsTrue(response.Success);
        }
    }
}
