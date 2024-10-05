using Shop.UserRegistrationService.Abstractions;
using Shop.UserRegistrationService.Dto;
using Shop.UserRegistrationService.Models;

namespace Shop.UserRegistrationService.Services
{
    public class UserService : IUserService
    {
        public const string USER_API_URL = "http://ShopUserAPI:8080/";
        private readonly HttpClient _httpClient;
        private readonly IPasswordHasherService _passwordHasherService;

        public UserService(HttpClient httpClient, IPasswordHasherService passwordHasherService)
        {
            _httpClient = httpClient;
            _passwordHasherService = passwordHasherService;
        }

        public async Task<Guid> CreateUserAsync(UserRegistrationModel userRegistrationModel)
        {
            var userModelDto = new UserModelDto(userRegistrationModel.Id, 
                userRegistrationModel.UserName, 
                userRegistrationModel.Email,
                userRegistrationModel.Telephone, 
                await _passwordHasherService.GeneratePasswordHashAsync(userRegistrationModel.Password), 
                userRegistrationModel.Role);

            var response = await _httpClient.PostAsJsonAsync($"{USER_API_URL}user", userModelDto);

            return Guid.Empty;
        }
    }
}
