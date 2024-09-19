namespace Shop.UserRegistrationService.Abstractions
{
    public interface IUserRegistrationServices
    {
        Task<string> UserRegistrationAsync(Guid id, string userName, string email, string telephone, string password);
    }
}