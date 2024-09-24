using Grpc.Net.Client;
using Shop.UserRegistrationService.Abstractions;
using Shop.UserRegistrationService.Enum;

namespace Shop.UserRegistrationService.Services
{
    public class JwtService : IJwtService
    {
        public async Task<string> GenerateTokenAsync(Guid id, UserRole role)
        {
            using var channel = GrpcChannel.ForAddress("http://shopjwtproviderservice:8080");
            // создаем клиент
            var client = new JwtToken.JwtTokenClient(channel);
            // создание запроса(для генерации jwt token)
            JwtRequest request = new JwtRequest { Id = id.ToString(), Role = role.ToString() };
            // получение ответа
            JwtReply response = await client.GenerateJwtTokenAsync(request);
            return response.Token;
        }
    }
}
