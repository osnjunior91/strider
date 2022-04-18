using Strider.Lib.Strider.Lib.Domain.Queries;
using System;

namespace Strider.Domain.Queries.Users.Queries
{
    public class VerifyExistFollowerQuery : Query
    {
        public VerifyExistFollowerQuery(Guid userId, Guid userFollowId)
        {
            UserId = userId;
            UserFollowId = userFollowId;
        }

        public Guid UserId { get; private set; }
        public Guid UserFollowId { get; private set; }
    }
}
