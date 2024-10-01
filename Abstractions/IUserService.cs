using Shop.UserRegistrationService.Models;

namespace Shop.UserRegistrationService.Abstractions
{
    public interface IUserService
    {
        Task<Guid> CreateUserAsync(UserRegistrationModel userRegistrationModel);
    }
}