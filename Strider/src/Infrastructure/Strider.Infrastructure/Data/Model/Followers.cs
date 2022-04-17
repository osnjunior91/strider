using Strider.Lib.Strider.Lib.Infrastructure.Data.Models;
using System;

namespace Strider.Infrastructure.Data.Model
{
    public class Followers : Entity
    {
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public Guid FollowerId { get; private set; }
        public User Follower { get; private set; }

        public Followers() { }

        public Followers(Guid userId, Guid followerId)
        {
            UserId = userId;
            FollowerId = followerId;
        }

        public Followers(Guid userId, User user, Guid followerId, User follower)
        {
            UserId = userId;
            User = user;
            FollowerId = followerId;
            Follower = follower;
        }
    }
}
