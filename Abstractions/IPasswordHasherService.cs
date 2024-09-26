namespace Shop.UserRegistrationService.Abstractions
{
    public interface IPasswordHasherService
    {
        Task<string> GeneratePasswordHash(string password);
        Task<string> VerifyPassword(string password, string hashPassword);
    }
}