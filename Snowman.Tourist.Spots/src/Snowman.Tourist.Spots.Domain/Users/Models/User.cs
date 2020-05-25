using Snowman.Tourist.Spots.Domain.Users.Validations;
using Snowman.Tourist.Spots.Shared.Domain.Models;
using System;
using System.Collections.Generic;

namespace Snowman.Tourist.Spots.Domain.Users.Models
{
    public class User : Entity
    {
        public User(string externalId, string name, string email, string phoneNumber)
        {
            ExternalId = externalId;
            Update(name, email, phoneNumber);
        }

        public string ExternalId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ExternalId;
            yield return Name;
            yield return Email;
            yield return PhoneNumber;
        }

        public void Update(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Validate(this, new UserValidator());
        }
    }
}
