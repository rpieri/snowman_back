using Snowman.Tourist.Spots.Domain.Users.Commands;
using Snowman.Tourist.Spots.Shared.ViewModels;
using Snowman.Tourist.Spots.ViewModels.Validators;
using System;

namespace Snowman.Tourist.Spots.ViewModels.Users
{
    public class AddUserViewModel : ViewModelToCommand<AddUserCommand>
    {
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public override AddUserCommand Mapping() => new AddUserCommand(ExternalId, Name, Email, PhoneNumber);

        public override bool Validate()
        {
            InsertValidation(this, new AddUserViewModelValidator());
            return ViewModelIsValid();
        }
    }
}
