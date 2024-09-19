using Shop.UserRegistrationService.Abstractions;
using Shop.UserRegistrationService.CustomException;
using Shop.UserRegistrationService.Models;

namespace Shop.UserRegistrationService.Services
{
    public class UserRegistrationServices : IUserRegistrationServices
    {
        private readonly IJwtService _jwtService;
        public UserRegistrationServices(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }
        public async Task<string> UserRegistrationAsync(Guid id, string userName, string email, string telephone, string password)
        {
            var (user, error) = UserRegistrationModel.Create(id, userName, email, telephone, password);
            if (string.IsNullOrEmpty(error))
            {
                string token = await _jwtService.GenerateTokenAsync(id);
                return token;
            }
            throw new ValidatorException(error);
        }
    }
}
