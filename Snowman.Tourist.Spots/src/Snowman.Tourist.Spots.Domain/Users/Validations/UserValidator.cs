using FluentValidation;
using Snowman.Tourist.Spots.Domain.Users.Models;

namespace Snowman.Tourist.Spots.Domain.Users.Validations
{
    internal class UserValidator : AbstractValidator<User>
    {
        internal UserValidator()
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
