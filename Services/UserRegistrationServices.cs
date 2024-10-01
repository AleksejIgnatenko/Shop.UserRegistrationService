using Shop.UserRegistrationService.Abstractions;
using Shop.UserRegistrationService.CustomException;
using Shop.UserRegistrationService.Enums;
using Shop.UserRegistrationService.Models;

namespace Shop.UserRegistrationService.Services
{
    public class UserRegistrationServices : IUserRegistrationServices
    {
        private readonly IJwtService _jwtService;
        private readonly IUserRegistrationRepository _userRegistrationRepository;
        private readonly IUserService _userService;
        private readonly HttpClient _httpClient;
        public UserRegistrationServices(IJwtService jwtService, IUserRegistrationRepository userRegistrationRepository, IUserService userService, HttpClient httpClient)
        {
            _jwtService = jwtService;
            _userRegistrationRepository = userRegistrationRepository;
            _userService = userService;
            _httpClient = httpClient;
        }
        public async Task<string> UserRegistrationAsync(Guid id, string userName, string email, string telephone, string password, 
            UserRole role, string locationRegistration, DateTime DataRegistration)
        {
            var (user, error) = UserRegistrationModel.Create(id, userName, email, telephone, password, role, locationRegistration, DataRegistration);
            if (string.IsNullOrEmpty(error))
            {
                string token = await _jwtService.GenerateTokenAsync(id, role);
                Guid userId = await _userRegistrationRepository.CreatingUserRegistrationAsync(user);
                Guid createUserId = await _userService.CreateUserAsync(user);
                return token;
            }
            throw new ValidatorException(error);
        }
    }
}
