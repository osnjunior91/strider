using NUnit.Framework;
using Strider.Domain.Queries.Post.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strider.Test.Domain.Test.Queries.Posts.Queries
{
    public class PostQueriesTest
    {
        private List<Infrastructure.Data.Model.Post> posts;
        [SetUp]
        public void Setup() 
        {
            posts = new List<Infrastructure.Data.Model.Post>();
        }

        [Test]
        public void PostQueriesTest_GetPostsDay_IsOk()
        {
            var userId = Guid.NewGuid();
            posts.Add(new Infrastructure.Data.Model.Post("Test1", userId, null, null, null));
            posts.Add(new Infrastructure.Data.Model.Post("Test2", Guid.NewGuid(), null, null, null));
            posts.Add(new Infrastructure.Data.Model.Post("Test3", userId, null, null, null));

            posts[0].DeleteEntity();

            var response = posts.AsQueryable().Count(PostQueries.GetPostsDay(userId));
            Assert.IsTrue(response == 1);
        }

        [Test]
        public void PostQueriesTest_GetById_IsOk()
        {
            posts.Add(new Infrastructure.Data.Model.Post("Test1", Guid.NewGuid(), null, null, null));
            posts.Add(new Infrastructure.Data.Model.Post("Test2", Guid.NewGuid(), null, null, null));
            posts.Add(new Infrastructure.Data.Model.Post("Test3", Guid.NewGuid(), null, null, null));
            var response = posts.AsQueryable().Count(PostQueries.GetById(posts[0].Id));
            Assert.IsTrue(response == 1);
        }

        [Test]
        public void PostQueriesTest_GetUserLastPost_IsOk()
        {
            var userId = Guid.NewGuid();
            posts.Add(new Infrastructure.Data.Model.Post("Test1", userId, null, null, null));
            posts.Add(new Infrastructure.Data.Model.Post("Test2", Guid.NewGuid(), null, null, null));

            posts[0].DeleteEntity();

            var response = posts.AsQueryable().Count(PostQueries.GetUserLastPost(userId));
            Assert.IsTrue(response == 0);
        }
        [TestCase("", 3)]
        [TestCase("Text", 3)]
        [TestCase("right", 2)]
        [TestCase("WRONG", 1)]
        [TestCase("Apple", 0)]
        public void PostQueriesTest_GetAllPostsByText_IsOk(string text, int matches)
        {
            posts.Add(new Infrastructure.Data.Model.Post("Right text", Guid.NewGuid(), null, null, null));
            posts.Add(new Infrastructure.Data.Model.Post("Wrong Text", Guid.NewGuid(), null, null, null));
            posts.Add(new Infrastructure.Data.Model.Post("Text RIGHT", Guid.NewGuid(), null, null, null));
            var response = posts.AsQueryable().Count(PostQueries.GetAllPostsByText(text));
            Assert.IsTrue(response == matches);
        }

        [TestCase("", 2)]
        [TestCase("Hello", 1)]
        public void PostQueriesTest_GetAllPostsOnlyFollowing_IsOk(string text, int matches)
        {
            var userId = Guid.NewGuid();

            List<Infrastructure.Data.Model.Followers> users = new List<Infrastructure.Data.Model.Followers>()
            {
                new Infrastructure.Data.Model.Followers(Guid.NewGuid(), userId),
                new Infrastructure.Data.Model.Followers(Guid.NewGuid(), Guid.NewGuid()),
            };


            posts.Add(new Infrastructure.Data.Model.Post("Test1", userId, null, null, null));
            posts.Add(new Infrastructure.Data.Model.Post("Test2", Guid.NewGuid(), null, null, null));
            posts.Add(new Infrastructure.Data.Model.Post("Test3", userId, null, null, null));
            posts.Add(new Infrastructure.Data.Model.Post("Hello World", userId, null, null, null));

            posts[0].DeleteEntity();

            var response = posts.AsQueryable().Count(PostQueries.GetAllPostsOnlyFollowing(text, users));
            Assert.IsTrue(response == matches);
        }
    }
}
