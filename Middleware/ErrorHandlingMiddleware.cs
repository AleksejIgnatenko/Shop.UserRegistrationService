using Shop.UserRegistrationService.CustomException;
using System.Text.Json;

namespace Shop.UserRegistrationService.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidatorException ex)
            {
                _logger.LogError(ex.Message);

                // Создание ответа с кодом состояния 400
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                var errors = ex.Message.Split('\n')
                    .Where(error => !string.IsNullOrEmpty(error))
                    .ToList();

                var result = JsonSerializer.Serialize(new { error = errors });
                await context.Response.WriteAsync(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                // Создание ответа с кодом состояния 400
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                var result = JsonSerializer.Serialize(new { error = ex.Message });
                await context.Response.WriteAsync(result);
            }
        }
    }
}
