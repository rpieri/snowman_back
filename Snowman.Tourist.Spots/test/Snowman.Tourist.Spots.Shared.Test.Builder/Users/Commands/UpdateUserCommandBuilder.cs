using Snowman.Tourist.Spots.Domain.Users.Commands;
using System;

namespace Snowman.Tourist.Spots.Shared.Test.Builder.Users.Commands
{
    public class UpdateUserCommandBuilder
    {
        private string externalId;
        private string name;
        private string email;
        private string phoneNumber;

        public UpdateUserCommandBuilder()
        {
            externalId = "5454cc545454";
            name = "User Test";
            email = "user@test.com";
            phoneNumber = "+554499914066";
        }

        public UpdateUserCommand Builder() => new UpdateUserCommand(externalId, name, email, phoneNumber);

        public UpdateUserCommandBuilder WithExternalId(string value)
        {
            externalId = value;
            return this;
        }

        public UpdateUserCommandBuilder WithName(string value)
        {
            name = value;
            return this;
        }

        public UpdateUserCommandBuilder WithEmail(string value)
        {
            email = value;
            return this;
        }

        public UpdateUserCommandBuilder WithPhoneNumber(string value)
        {
            phoneNumber = value;
            return this;
        }
    }
}
