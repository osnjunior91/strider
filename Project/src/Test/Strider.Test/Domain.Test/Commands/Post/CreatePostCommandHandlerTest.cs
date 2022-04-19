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
    public class CreatePostCommandHandlerTest
    {
        private Mock<IPostRepository> _postRepository;
        [SetUp]
        public void Setup()
        {
            _postRepository = new Mock<IPostRepository>();
        }
        [TestCase("First Test", "00000000-0000-0000-0000-000000000000")]
        [TestCase("", "127f0c34-d774-44d4-8d9e-d3c3df8af908")]
        public async Task When_Handle_Invalid_Params(string text, Guid userId)
        {
            var handle = new CreatePostCommandHandler(_postRepository.Object);
            var response = await handle.Handle(new CreatePostCommand(text, userId), new System.Threading.CancellationToken());
            Assert.That(response, Is.InstanceOf<CommandResult>());
            Assert.IsFalse(response.Success);
        }

        [Test]
        public async Task When_Handle_Invalid_More5Posts()
        {
            _postRepository.Setup(m => m.CountAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Post, bool>>>())).ReturnsAsync(5);
            var handle = new CreatePostCommandHandler(_postRepository.Object);
            var response = await handle.Handle(new CreatePostCommand("Texto", Guid.NewGuid()), new System.Threading.CancellationToken());
            Assert.That(response, Is.InstanceOf<CommandResult>());
            Assert.IsFalse(response.Success);
            Assert.IsTrue(response.Message.Equals("Not allowed to post more today. Try again tomorrow."));
        }

        [Test]
        public async Task When_Handle_IsOk()
        {
            _postRepository.Setup(m => m.CountAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Post, bool>>>())).ReturnsAsync(4);
            _postRepository.Setup(m => m.CreatedAsync(It.IsAny<Infrastructure.Data.Model.Post>())).Verifiable();
            var handle = new CreatePostCommandHandler(_postRepository.Object);
            var response = await handle.Handle(new CreatePostCommand("Texto", Guid.NewGuid()), new System.Threading.CancellationToken());
            Assert.That(response, Is.InstanceOf<CommandResult>());
            Assert.IsTrue(response.Success);
        }

    }
}
