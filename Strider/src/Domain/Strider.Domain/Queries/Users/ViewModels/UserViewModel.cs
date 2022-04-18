using System;

namespace Strider.Domain.Queries.Users.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string username, DateTime joined,
            int followers, int following, int numberOfPost)
        {
            Username = username;
            Joined = string.Format("{0:MMMM dd, yyyy}", joined);
            Followers = followers;
            Following = following;
            NumberOfPost = numberOfPost;
        }
        public string Username { get; private set; }
        public string Joined { get; private set; }
        public int Followers { get; private set; }
        public int Following { get; private set; }
        public int NumberOfPost { get; private set; }
    }
}
