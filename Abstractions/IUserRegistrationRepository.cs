using Shop.UserRegistrationService.Entities;
using Shop.UserRegistrationService.Models;

namespace Shop.UserRegistrationService.Abstractions
{
    public interface IUserRegistrationRepository
    {
        Task<Guid> CreatingUserRegistrationAsync(UserRegistrationModel userRegistrationModel);
        Task<List<UserRegistrationEntity>> GetAllUserRegistrations();
        Task<UserRegistrationEntity> GetByIdUserRegistration(Guid id);
    }
}