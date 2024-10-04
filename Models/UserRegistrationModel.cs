using FluentValidation.Results;
using Shop.UserRegistrationService.Enums;
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
        public UserRole Role { get; }
        public string LocationRegistration {  get; } = string.Empty;
        public DateTime DataRegistration { get; }

        public UserRegistrationModel(Guid id, string locationRegistration, DateTime dataRegistration)
        {
            Id = id;
            LocationRegistration = locationRegistration;
            DataRegistration = dataRegistration;
        }

        private UserRegistrationModel(Guid id, string userName, string email, string telephone, string password, UserRole role, string locationRegistration, DateTime dataRegistration)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Telephone = telephone;
            Password = password;
            Role = role;
            LocationRegistration = locationRegistration;
            DataRegistration = dataRegistration;
        }

        public static UserRegistrationModel Create(Guid id, string locationRegistration, DateTime dataRegistration)
        {
            return new UserRegistrationModel(id, locationRegistration, dataRegistration);
        }

        public static (UserRegistrationModel user, string error) Create(Guid id, string userName, string email, string telephone, string password, UserRole role, string locationRegistration, DateTime DataRegistration)
        {
            string error = string.Empty;
            UserRegistrationModel user = new UserRegistrationModel(id, userName, email, telephone, password, role, locationRegistration, DataRegistration);
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
