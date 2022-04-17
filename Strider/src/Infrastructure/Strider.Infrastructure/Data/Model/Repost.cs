using Strider.Lib.Strider.Lib.Infrastructure.Data.Models;
using System;

namespace Strider.Infrastructure.Data.Model
{
    public class Repost : Post
    {
        public Guid? RepostedFromId { get; private set; }
        public Post RepostedFrom { get; private set; }

        public Repost() { }

        public Repost(string text, Guid userId, User user,
            Guid? repostedFromId, Post repostedFrom) : base(text, userId, user)
        {
            RepostedFromId = repostedFromId;
            RepostedFrom = repostedFrom;
        }

    }
}
