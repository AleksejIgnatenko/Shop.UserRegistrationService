using Shop.UserRegistrationService.Models;

namespace Shop.UserRegistrationService.Abstractions
{
    public interface IUserGrpcService
    {
        Task<Guid> CreateUserAsync(UserRegistrationModel userRegistrationModel);
    }
}