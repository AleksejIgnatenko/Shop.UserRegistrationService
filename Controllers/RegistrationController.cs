using Microsoft.AspNetCore.Mvc;
using Shop.UserRegistrationService.Abstractions;
using Shop.UserRegistrationService.Contracts;
using Shop.UserRegistrationService.CustomException;

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
                Console.WriteLine(usersRequest.UserName + " " + usersRequest.Email);
                var token = await _userRegistrationServices.UserRegistrationAsync(Guid.NewGuid(), usersRequest.UserName, usersRequest.Email, usersRequest.Telephone, usersRequest.Password);
                //return Ok(token);
                return Ok(new { message = token });
            }
            catch (ValidatorException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
