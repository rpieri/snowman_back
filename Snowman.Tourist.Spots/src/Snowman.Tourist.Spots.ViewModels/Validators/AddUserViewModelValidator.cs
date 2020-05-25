using FluentValidation;
using Snowman.Tourist.Spots.ViewModels.Users;

namespace Snowman.Tourist.Spots.ViewModels.Validators
{
    internal class AddUserViewModelValidator : AbstractValidator<AddUserViewModel>
    {
        internal AddUserViewModelValidator()
        {
            RuleFor(e => e.ExternalId)
                .NotEmpty();

            RuleFor(e => e.Name)
                .NotEmpty();

            RuleFor(e => e.Email)
                .NotEmpty();

        }
    }
}
