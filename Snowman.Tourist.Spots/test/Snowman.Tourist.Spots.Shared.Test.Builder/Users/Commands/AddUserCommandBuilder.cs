using Snowman.Tourist.Spots.Domain.Users.Commands;
using System;

namespace Snowman.Tourist.Spots.Shared.Test.Builder.Users.Commands
{
    public class AddUserCommandBuilder
    {
        private string externalId;
        private string name;
        private string email;
        private string phoneNumber;
      
        public AddUserCommandBuilder()
        {
            externalId = "eweee0944090";
            name = "User Test";
            email = "user@test.com";
            phoneNumber = "+554499914066";
        }

        public AddUserCommand Builder() => new AddUserCommand(externalId, name, email, phoneNumber);

        public AddUserCommandBuilder WithExternalId(string value)
        {
            externalId = value;
            return this;
        }

        public AddUserCommandBuilder WithName(string value)
        {
            name = value;
            return this;
        }

        public AddUserCommandBuilder WithEmail(string value)
        {
            email = value;
            return this;
        }

        public AddUserCommandBuilder WithPhoneNumber(string value)
        {
            phoneNumber = value;
            return this;
        }
    }
}
