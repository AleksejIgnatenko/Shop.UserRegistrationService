using Shop.UserRegistrationService.Models;

namespace Shop.UserRegistrationService.Abstractions
{
    public interface IUserRegistrationRepository
    {
        Task<Guid> CreatingUserRegistrationAsync(UserRegistrationModel userRegistrationModel);
        Task<Guid> DeleteUserRegistrationAsync(UserRegistrationModel userRegistrationModel);
        Task<Guid> UpdateUserRegistrationAsync(UserRegistrationModel userRegistrationModel);
    }
}