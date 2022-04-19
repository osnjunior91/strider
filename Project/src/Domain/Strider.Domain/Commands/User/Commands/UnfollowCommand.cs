using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strider.Domain.Commands.User.Commands
{
    public class UnfollowCommand : FollowCommand
    {
        public UnfollowCommand()
        {
        }

        public UnfollowCommand(Guid userId, Guid userFollowId) : base(userId, userFollowId)
        {
        }
    }
}
