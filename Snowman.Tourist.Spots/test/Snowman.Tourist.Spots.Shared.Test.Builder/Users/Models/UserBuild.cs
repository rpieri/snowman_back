using Snowman.Tourist.Spots.Domain.Users.Models;
using System;

namespace Snowman.Tourist.Spots.Shared.Test.Builder.Users.Models
{
    public class UserBuild
    {
        private string externalId;
        private string name;
        private string email;
        private string phoneNumber;

        public UserBuild()
        {
            externalId ="4488798989cdd";
            name = "User Test";
            email = "user@email.com";
            phoneNumber = "+55 44 999140366";
        }

        public User Builder() => new User(externalId, name, email, phoneNumber);

        public UserBuild WithExternalId(string value)
        {
            externalId = value;
            return this;
        }

        public UserBuild WithName(string value)
        {
            name = value;
            return this;
        }

        public UserBuild WithEmail(string value)
        {
            email = value;
            return this;
        }

        public UserBuild WithPhoneNumber(string value)
        {
            phoneNumber = value;
            return this;
        }
    }
}
