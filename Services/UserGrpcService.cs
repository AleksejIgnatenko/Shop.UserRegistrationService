using Grpc.Net.Client;
using Shop.UserRegistrationService.Abstractions;
using Shop.UserRegistrationService.Models;

namespace Shop.UserRegistrationService.Services
{
    public class UserGrpcService : IUserGrpcService
    {
        public async Task<Guid> CreateUserAsync(UserRegistrationModel userRegistrationModel)
        {
            using var channel = GrpcChannel.ForAddress("http://ShopUserAPI:8080");
            // Создание клиента клиент
            var client = new UserGrpc.UserGrpcClient(channel);
            // Создание запроса
            UserRequest request = new UserRequest
            {
                Id = userRegistrationModel.Id.ToString(),
                UserName = userRegistrationModel.UserName,
                Email = userRegistrationModel.Email,
                Telephone = userRegistrationModel.Telephone,
                Password = userRegistrationModel.Password,
                Role = userRegistrationModel.Role.ToString(),
            };
            // получение ответа
            UserReply reply = await client.CreateUserAsync(request);
            return Guid.Parse(reply.Id);
        }
    }
}
