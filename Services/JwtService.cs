using Grpc.Net.Client;
using Shop.UserRegistrationService.Abstractions;

namespace Shop.UserRegistrationService.Services
{
    public class JwtService : IJwtService
    {
        public async Task<string> GenerateTokenAsync(Guid id)
        {
            using var channel = GrpcChannel.ForAddress("http://shopjwtproviderservice:8080");
            // создаем клиент
            var client = new JwtToken.JwtTokenClient(channel);
            // создание запроса(для генерации jwt token)
            JwtRequest request = new JwtRequest { Id = id.ToString(), Role = "User" };
            // получение ответа
            JwtReply response = await client.GenerateJwtTokenAsync(request);
            return response.Token;
        }
    }
}
