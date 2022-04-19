using Strider.Lib.Strider.Lib.Domain.Commands;
using System;

namespace Strider.Domain.Commands.User.Commands
{
    public class FollowCommand : Command
    {
        public FollowCommand()
        {
        }

        public FollowCommand(Guid userId, Guid userFollowId)
        {
            UserId = userId;
            UserFollowId = userFollowId;
        }

        public Guid UserId { get; set; }
        public Guid UserFollowId { get; set; }
    }
}
