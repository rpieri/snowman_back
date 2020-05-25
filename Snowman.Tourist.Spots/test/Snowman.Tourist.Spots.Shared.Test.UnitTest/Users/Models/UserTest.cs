using NUnit.Framework;
using Snowman.Tourist.Spots.Shared.Test.Builder.Users.Models;
using System;

namespace Snowman.Tourist.Spots.Shared.Test.UnitTest.Users.Models
{
    public class UserTest
    {
        [Test]
        public void User_IsDiferent()
        {
            var user = new UserBuild().Builder();
            var otheUser = new UserBuild().WithName("name test 2").WithEmail("test2@email.com");

            Assert.AreNotEqual(user, otheUser);
        }

        [Test]
        public void User_IsEqual()
        {
            var user = new UserBuild().Builder();
            var otherUser = user;
            Assert.AreEqual(user, otherUser);
        }
    }
}
