using Microsoft.AspNetCore.Mvc;
using UserRegistration.Modal;
using UserRegistration.Service.UserRegistrationService;

namespace UserRegistration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserRegistrationController : ControllerBase
    {
        
        private IUserRegistrationService userRegistrationService;

        public UserRegistrationController(IUserRegistrationService userRegistrationService)
        {
            this.userRegistrationService = userRegistrationService;
        }

        [Consumes("application/json")]
        [HttpPost(Name = "registerUser")]
        public UserRegistrationResponseEntity RegisterUser([FromBody] UserRegistrationRequestEntity userRegistrationRequestEntity)
        {
            return userRegistrationService.RegisterUser(userRegistrationRequestEntity);
        }
    }
}