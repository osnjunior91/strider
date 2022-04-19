using Strider.Lib.Strider.Lib.Infrastructure.Data.Models;
using System;

namespace Strider.Infrastructure.Data.Model
{
    public class Post : Entity
    {
        public string Text { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public Guid? RepostedFromId { get; private set; }
        public Post RepostedFrom { get; private set; }

        public Post() { }

        public Post(string text, Guid userId, User user,
            Guid? repostedFromId, Post repostedFrom)
        {
            Text = text;
            UserId = userId;
            User = user;
            RepostedFromId = repostedFromId;
            RepostedFrom = repostedFrom;
        }

    }
}
