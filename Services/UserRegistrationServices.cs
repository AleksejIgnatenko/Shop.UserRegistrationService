using Shop.UserRegistrationService.Abstractions;
using Shop.UserRegistrationService.CustomException;
using Shop.UserRegistrationService.Models;

namespace Shop.UserRegistrationService.Services
{
    public class UserRegistrationServices : IUserRegistrationServices
    {
        private readonly IJwtService _jwtService;
        private readonly IUserRegistrationRepository _userRegistrationRepository;
        public UserRegistrationServices(IJwtService jwtService, IUserRegistrationRepository userRegistrationRepository)
        {
            _jwtService = jwtService;
            _userRegistrationRepository = userRegistrationRepository;
        }
        public async Task<string> UserRegistrationAsync(Guid id, string userName, string email, string telephone, string password)
        {
            var (user, error) = UserRegistrationModel.Create(id, userName, email, telephone, password);
            if (string.IsNullOrEmpty(error))
            {
                string token = await _jwtService.GenerateTokenAsync(id);
                Guid userId = await _userRegistrationRepository.CreatingUserRegistrationAsync(user);
                return token;
            }
            throw new ValidatorException(error);
        }
    }
}
