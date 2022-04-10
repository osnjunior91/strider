using System;

namespace Strider.Infra.Data.Model
{
    public class User : Entity
    {
        public User(string username, DateTime joined, 
            int followers, int following, int numberOfPost)
        {
            Username = username;
            Joined = joined;
            Followers = followers;
            Following = following;
            NumberOfPost = numberOfPost;
        }
        public User(string username)
        {
            Username = username;
            Joined = DateTime.Now;
            Followers = 0;
            Following = 0;
            NumberOfPost = 0;
        }

        public string Username { get; private set; }
        public DateTime Joined { get; private set; }
        public int Followers { get; private set; }
        public int Following { get; private set; }
        public int NumberOfPost { get; private set; }

    }
}
