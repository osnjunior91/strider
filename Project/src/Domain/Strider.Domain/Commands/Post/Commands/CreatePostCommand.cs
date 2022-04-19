using Strider.Lib.Strider.Lib.Domain.Commands;
using System;

namespace Strider.Domain.Commands.Post.Commands
{
    public class CreatePostCommand : Command
    {
        public CreatePostCommand()
        {
        }

        public CreatePostCommand(string text, Guid userId)
        {
            Text = text;
            UserId = userId;
        }

        public string Text { get; set; }
        public Guid UserId { get; set; }
    }
}
