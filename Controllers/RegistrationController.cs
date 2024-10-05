using Microsoft.AspNetCore.Mvc;
using Shop.UserRegistrationService.Abstractions;
using Shop.UserRegistrationService.Contracts;
using Shop.UserRegistrationService.CustomException;
using Shop.UserRegistrationService.Enums;
using Shop.UserRegistrationService.Models;

namespace Shop.UserRegistrationService.Controllers
{
    [ApiController]
    [Route("api/UserRegistration")]
    public class RegistrationController : ControllerBase
    {
        private readonly IUserRegistrationServices _userRegistrationServices;

        public RegistrationController(IUserRegistrationServices userRegistrationServices)
        {
            _userRegistrationServices = userRegistrationServices;
        }

        [HttpPost]
        public async Task<ActionResult<string>> UserRegistrationAsync([FromBody] UsersRequest usersRequest)
        {
            var token = await _userRegistrationServices.UserRegistrationAsync(
                Guid.NewGuid(),
                usersRequest.UserName,
                usersRequest.Email,
                usersRequest.Telephone,
                usersRequest.Password,
                UserRole.User,
                HttpContext.Connection.RemoteIpAddress?.ToString() ?? throw new Exception(),
                DateTime.UtcNow);

            return Ok(token);
        }

        [HttpGet]
        [Route("getAllUserRegistrations")]
        public async Task<ActionResult<List<UserRegistrationModel>>> GetAllUserRegistrationsAsync()
        {
            return await _userRegistrationServices.GetAllUserRegistrationsAsync();
        }

        [HttpGet]
        [Route("getByIdUserRegistration")]
        public async Task<ActionResult<UserRegistrationModel>> GetByIdUserRegistrationAsync(Guid id)
        {
            return await _userRegistrationServices.GetByIdUserRegistrationAsync(id);
        }
    }
}
