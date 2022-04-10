using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Strider.Infra.Data.Model
{
    public class Followers : Entity
    {
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public Guid FollowerId { get; private set; }
        public User Follower{ get; private set; }
    }
}
