using Grpc.Net.Client;
using Shop.UserRegistrationService.Abstractions;
using Shop.UserRegistrationService.Enum;

namespace Shop.UserRegistrationService.Services
{
    public class JwtService : IJwtService
    {
        public async Task<string> GenerateTokenAsync(Guid id, UserRole role)
        {
            using var channel = GrpcChannel.ForAddress("http://ShopJwtProviderService:8080");
            // Создание клиента клиент
            var client = new JwtToken.JwtTokenClient(channel);
            // Создание запроса
            JwtRequest request = new JwtRequest { Id = id.ToString(), Role = role.ToString() };
            // получение ответа
            JwtReply response = await client.GenerateJwtTokenAsync(request);
            return response.Token;
        }
    }
}
