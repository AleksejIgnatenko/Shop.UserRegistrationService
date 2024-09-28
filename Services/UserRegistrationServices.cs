using Shop.UserRegistrationService.Abstractions;
using Shop.UserRegistrationService.CustomException;
using Shop.UserRegistrationService.Enum;
using Shop.UserRegistrationService.Models;

namespace Shop.UserRegistrationService.Services
{
    public class UserRegistrationServices : IUserRegistrationServices
    {
        private readonly IJwtService _jwtService;
        private readonly IUserRegistrationRepository _userRegistrationRepository;
        private readonly IUserGrpcService _userGrpcService;
        public UserRegistrationServices(IJwtService jwtService, IUserRegistrationRepository userRegistrationRepository, IUserGrpcService userGrpcService)
        {
            _jwtService = jwtService;
            _userRegistrationRepository = userRegistrationRepository;
            _userGrpcService = userGrpcService;
        }
        public async Task<string> UserRegistrationAsync(Guid id, string userName, string email, string telephone, string password, 
            UserRole role, string locationRegistration, DateTime DataRegistration)
        {
            var (user, error) = UserRegistrationModel.Create(id, userName, email, telephone, password, role, locationRegistration, DataRegistration);
            if (string.IsNullOrEmpty(error))
            {
                string token = await _jwtService.GenerateTokenAsync(id, role);
                Guid userId = await _userRegistrationRepository.CreatingUserRegistrationAsync(user);
                Guid createUserId = await _userGrpcService.CreateUserAsync(user);
                return token;
            }
            throw new ValidatorException(error);
        }
    }
}
