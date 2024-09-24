using Microsoft.AspNetCore.Mvc;
using Shop.UserRegistrationService.Abstractions;
using Shop.UserRegistrationService.Contracts;
using Shop.UserRegistrationService.CustomException;
using Shop.UserRegistrationService.Enum;

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
            try
            {
                var token = await _userRegistrationServices.UserRegistrationAsync(
                    Guid.NewGuid(),
                    usersRequest.UserName,
                    usersRequest.Email,
                    usersRequest.Telephone,
                    usersRequest.Password,
                    UserRole.User,
                    usersRequest.LocationRegistration,
                    DateTime.UtcNow);

                return Ok(token);
            }
            catch (ValidatorException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
