using System;

namespace Strider.Infra.Data.Model
{
    public class User : Entity
    {
        public User(string username, DateTime joined)
        {
            Username = username;
            Joined = joined;
        }
        public User(string username)
        {
            Username = username;
            Joined = DateTime.Now;
        }

        public string Username { get; private set; }
        public DateTime Joined { get; private set; }

    }
}
