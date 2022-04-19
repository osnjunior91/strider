using NUnit.Framework;
using Strider.Domain.Queries.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Strider.Test.Domain.Test.Queries.User.Queries
{
    public class UserQueriesTest
    {
        private List<Infrastructure.Data.Model.User> users;
        [SetUp]
        public void Setup()
        {
            users = new List<Infrastructure.Data.Model.User>();
            for (int i = 0; i < 4; i++)
            {
                users.Add(new Infrastructure.Data.Model.User("user0" + i, DateTime.Now));   
            }
        }

        [Test]
        public void UserQueriesTest_FindById_IsOk()
        {
            var response = users.AsQueryable().Count(UserQueries.GetById(users[0].Id));
            Assert.IsTrue(response == 1);
        }
    }
}
