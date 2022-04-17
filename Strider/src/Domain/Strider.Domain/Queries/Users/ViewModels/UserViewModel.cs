using Strider.Infrastructure.Data.Model;
using System;

namespace Strider.Domain.Queries.Users.ViewModels
{
    public class UserViewModel : User
    {
        public UserViewModel(string username, DateTime joined,
            int followers, int following, int numberOfPost) : base(username, joined)
        {
            Followers = followers;
            Following = following;
            NumberOfPost = numberOfPost;
        }
        public int Followers { get; private set; }
        public int Following { get; private set; }
        public int NumberOfPost { get; private set; }
    }
}
