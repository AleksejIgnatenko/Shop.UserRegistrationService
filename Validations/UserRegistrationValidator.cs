using FluentValidation;
using Shop.UserRegistrationService.Models;

namespace Shop.UserRegistrationService.Validation
{
    public class UserRegistrationValidator : AbstractValidator<UserRegistrationModel>
    {
        public UserRegistrationValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Please enter a username")
                .MinimumLength(2).WithMessage("The length of the username must be more than 1 character");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("The email address is incorrect");

            //RuleFor(x => x.Telephone)
            //    .Matches();

            RuleFor(x => x.Password)
                .MinimumLength(8).WithMessage("The password must be at least 8 characters long")
                .MaximumLength(16).WithMessage("The password must be no more than 16 characters long");
        }
    }
}
