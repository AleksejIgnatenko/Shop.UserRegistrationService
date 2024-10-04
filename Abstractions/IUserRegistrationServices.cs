using Shop.UserRegistrationService.Enums;
using Shop.UserRegistrationService.Models;

namespace Shop.UserRegistrationService.Abstractions
{
    public interface IUserRegistrationServices
    {
        Task<string> UserRegistrationAsync(
            Guid id,
            string userName,
            string email,
            string telephone,
            string password,
            UserRole role,
            string locationRegistration,
            DateTime DataRegistration);

        Task<List<UserRegistrationModel>> GetAllUserRegistrationsAsync();
        Task<UserRegistrationModel> GetByIdUserRegistrationAsync(Guid id);
    }
}