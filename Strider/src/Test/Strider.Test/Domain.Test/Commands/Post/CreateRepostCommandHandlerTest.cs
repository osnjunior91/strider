using Moq;
using NUnit.Framework;
using Strider.Domain.Commands.Post.CommandHandlers;
using Strider.Domain.Commands.Post.Commands;
using Strider.Infrastructure.Data.Repository.PostRepository;
using Strider.Lib.Strider.Lib.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Strider.Test.Domain.Test.Commands.Post
{
    public class CreateRepostCommandHandlerTest
    {
        private Mock<IPostRepository> _postRepository;
        [SetUp]
        public void Setup()
        {
            _postRepository = new Mock<IPostRepository>();
        }

        [TestCase("First Test", "00000000-0000-0000-0000-000000000000", "127f0c34-d774-44d4-8d9e-d3c3df8af908")]
        [TestCase("First Test", "127f0c34-d774-44d4-8d9e-d3c3df8af908",  "00000000-0000-0000-0000-000000000000")]
        [TestCase("", "127f0c34-d774-44d4-8d9e-d3c3df8af908", "127f0c34-d774-44d4-8d9e-d3c3df8af908")]
        public async Task When_Handle_Invalid_Params(string text, Guid userId, Guid repostedFromId)
        {
            var handle = new CreateRepostCommandHandler(_postRepository.Object);
            var response = await handle.Handle(new CreateRepostCommand(text, userId, repostedFromId), new System.Threading.CancellationToken());
            Assert.That(response, Is.InstanceOf<CommandResult>());
            Assert.IsFalse(response.Success);
        }

        [Test]
        public async Task When_Handle_RepostedFrom_NotFound()
        {
            _postRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Post, bool>>>())).ReturnsAsync(value: null);
            var handle = new CreateRepostCommandHandler(_postRepository.Object);
            var response = await handle.Handle(new CreateRepostCommand("Text", Guid.NewGuid(), Guid.NewGuid()), new System.Threading.CancellationToken());
            Assert.That(response, Is.InstanceOf<CommandResult>());
            Assert.IsFalse(response.Success);
            Assert.IsTrue(response.Message.Equals("Invalid RepostedFromId"));
        }

        [Test]
        public async Task When_Handle_Invalid_More5Posts()
        {
            _postRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Post, bool>>>())).ReturnsAsync(new Infrastructure.Data.Model.Post("Text", Guid.NewGuid(), null, null, null));
            _postRepository.Setup(m => m.CountAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Post, bool>>>())).ReturnsAsync(5);
            var handle = new CreateRepostCommandHandler(_postRepository.Object);
            var response = await handle.Handle(new CreateRepostCommand("Text", Guid.NewGuid(), Guid.NewGuid()), new System.Threading.CancellationToken());
            Assert.That(response, Is.InstanceOf<CommandResult>());
            Assert.IsFalse(response.Success);
            Assert.IsTrue(response.Message.Equals("Not allowed to post more today. Try again tomorrow."));
        }

        [Test]
        public async Task When_Handle_IsOk()
        {
            _postRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Post, bool>>>())).ReturnsAsync(new Infrastructure.Data.Model.Post("Text", Guid.NewGuid(), null, null, null));
            _postRepository.Setup(m => m.CountAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Post, bool>>>())).ReturnsAsync(4);
            var handle = new CreateRepostCommandHandler(_postRepository.Object);
            var response = await handle.Handle(new CreateRepostCommand("Text", Guid.NewGuid(), Guid.NewGuid()), new System.Threading.CancellationToken());
            Assert.That(response, Is.InstanceOf<CommandResult>());
            Assert.IsTrue(response.Success);
        }
    }
}
