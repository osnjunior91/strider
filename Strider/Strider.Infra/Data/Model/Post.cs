using System;

namespace Strider.Infra.Data.Model
{
    public class Post : Entity
    {
        public string Text { get; private set; }
        public DateTime Created { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public Guid? RepostedFromId { get; private set; }
        public Post RepostedFrom { get; private set; }
    }
}
