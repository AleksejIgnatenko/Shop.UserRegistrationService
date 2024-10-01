using Shop.UserRegistrationService.Enums;

namespace Shop.UserRegistrationService.Abstractions
{
    public interface IJwtService
    {
        Task<string> GenerateTokenAsync(Guid id, UserRole role);
    }
}