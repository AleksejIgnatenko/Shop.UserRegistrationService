using Shop.UserRegistrationService.Enums;

namespace Shop.UserRegistrationService.Dto
{
    public record UserModelDto (
        Guid Id,
        string UserName,
        string Email,
        string Telephone,
        string Password,
        UserRole Role
        );
}
