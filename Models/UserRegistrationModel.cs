using FluentValidation.Results;
using Shop.UserRegistrationService.Validation;

namespace Shop.UserRegistrationService.Models
{
    public class UserRegistrationModel
    {
        public Guid Id { get; }
        public string UserName { get; } = string.Empty;
        public string Email { get; } = string.Empty;
        public string Telephone { get; } = string.Empty;
        public string Password { get; } = string.Empty;

        private UserRegistrationModel(Guid id, string userName, string email, string telephone, string password)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Telephone = telephone;
            Password = password;
        }

        public static (UserRegistrationModel user, string error) Create(Guid id, string userName, string email, string telephone, string password)
        {
            string error = string.Empty;
            UserRegistrationModel user = new UserRegistrationModel(id, userName, email, telephone, password);
            UserRegistrationValidator userRegistrationValidator = new UserRegistrationValidator();
            ValidationResult result = userRegistrationValidator.Validate(user);
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    error += failure + "\n";
                }
            }
            return (user, error);
        }
    }
}
