using Grpc.Net.Client;
using Shop.UserRegistrationService.Abstractions;

namespace Shop.UserRegistrationService.Services
{
    public class JwtService : IJwtService
    {
        public async Task<string> GenerateTokenAsync(Guid id)
        {
            Console.WriteLine(id);
            // параметр - адрес сервера gRPC
            using var channel = GrpcChannel.ForAddress("https://localhost:7223");
            // создаем клиент
            var client = new JwtToken.JwtTokenClient(channel);
            // создание запроса(для генерации jwt token)
            JwtCreationRequest request = new JwtCreationRequest { Id = id.ToString() };
            // получение ответа
            JwtCreationReply response = await client.GenerateJwtTokenAsync(request);
            return response.Token;
        }
    }
}
