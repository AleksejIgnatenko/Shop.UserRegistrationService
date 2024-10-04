using Shop.UserRegistrationService.Entities;
using Shop.UserRegistrationService.Models;

namespace Shop.UserRegistrationService.Abstractions
{
    public interface IUserRegistrationRepository
    {
        Task<Guid> CreatingUserRegistrationAsync(UserRegistrationModel userRegistrationModel);
        Task<List<UserRegistrationModel>> GetAllUserRegistrationsAsync();
        Task<UserRegistrationModel> GetByIdUserRegistrationAsync(Guid id);
    }
}