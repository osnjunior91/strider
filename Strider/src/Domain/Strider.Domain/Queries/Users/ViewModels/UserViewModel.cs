using System;

namespace Strider.Domain.Queries.Users.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string username, DateTime joined,
            int followers, int following, int numberOfPost)
        {
            Username = username;
            Joined = joined;
            Followers = followers;
            Following = following;
            NumberOfPost = numberOfPost;
        }
        public string Username { get; private set; }
        public DateTime Joined { get; private set; }
        public int Followers { get; private set; }
        public int Following { get; private set; }
        public int NumberOfPost { get; private set; }
    }
}
