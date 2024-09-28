using Grpc.Net.Client;
using Shop.UserRegistrationService.Abstractions;

namespace Shop.UserRegistrationService.Services
{
    public class PasswordHasherService : IPasswordHasherService
    {
        public async Task<string> GeneratePasswordHashAsync(string password)
        {
            using var chaneel = GrpcChannel.ForAddress("http://ShopPasswordHasherService:8080");
            // Создание клиента клиент
            var client = new PasswordHasher.PasswordHasherClient(chaneel);
            // Создание запроса
            PasswordRequest request = new PasswordRequest { Password = password };
            // получение ответа
            PasswordHashReply reply = await client.GeneratePasswordHashAsync(request);
            return reply.PasswordHash;
        }

        public async Task<string> VerifyPasswordAsync(string password, string hashPassword)
        {
            using var chaneel = GrpcChannel.ForAddress("http://ShopPasswordHasherService:8080");
            // Создание клиента клиент
            var client = new PasswordHasher.PasswordHasherClient(chaneel);
            // Создание запроса
            PasswordVerificationRequest request = new PasswordVerificationRequest { Password = password, HashedPassword = hashPassword };
            // получение ответа
            PasswordVerificationReply reply = await client.VerifyPasswordAsync(request);
            Console.WriteLine(reply.IsPasswordVerify);
            return reply.IsPasswordVerify;
        }
    }
}
