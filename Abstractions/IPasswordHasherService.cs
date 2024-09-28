namespace Shop.UserRegistrationService.Abstractions
{
    public interface IPasswordHasherService
    {
        Task<string> GeneratePasswordHashAsync(string password);
        Task<string> VerifyPasswordAsync(string password, string hashPassword);
    }
}