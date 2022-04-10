using System;
using System.Collections.Generic;

namespace Strider.Infra.Data.Model
{
    public class Followers : Entity
    {
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public ICollection<User> FollowersList { get; private set; }
    }
}
