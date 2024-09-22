using Grpc.Net.Client;
using Shop.UserRegistrationService;
using Shop.UserRegistrationService.Abstractions;
using Shop.UserRegistrationService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRegistrationServices, UserRegistrationServices>();
builder.Services.AddScoped<IJwtService, JwtService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await ExecuteGrpcCallAsync();

app.Run();

async Task ExecuteGrpcCallAsync()
{
    Console.WriteLine("Sending message to gRPC server...");

    // Create a channel to communicate with the gRPC server
    using var channel = GrpcChannel.ForAddress("http://shopjwtproviderservice:8080");

    // Create a client
    var client = new JwtToken.JwtTokenClient(channel);
    JwtRequest request = new JwtRequest { Id = "1".ToString(), Role = "User" };
    // получение ответа
    JwtReply response = await client.GenerateJwtTokenAsync(request);

    // Output the server's response
    Console.WriteLine($"Ответ сервера: {response.Token}");
}
