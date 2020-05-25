using Snowman.Tourist.Spots.Domain.Users.Models;
using Snowman.Tourist.Spots.Shared.Domain.Commands;
using System;

namespace Snowman.Tourist.Spots.Domain.Users.Commands
{
    public class AddUserCommand : CommandToAddEntity<User>
    {
        public AddUserCommand(string externalId, string name, string email, string phoneNumber)
        {
            ExternalId = externalId;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public string ExternalId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        public override User Mapping(params object[] values) => new User(ExternalId, Name, Email, PhoneNumber);
    }
}
