using CaploittePayroll.ApplicationServices.AuthenticationModule;
using CaploittePayroll.BusinessObjects.AuthenticationModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaploittePayroll.BackendService.Controllers.AuthenticationModule
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost]
        [ActionName("UserLogin")]
        public IActionResult Login([FromBody] AccessTokenRequest loginDetails)
        {
            AuthenticationApplicationService apiUserAS = new AuthenticationApplicationService();

            AuthenticationResponse authenticate = apiUserAS.Authenticate(loginDetails);
            if (authenticate == null)
            {
                return Forbid();
            }

            return Ok(new
            {
                token = authenticate,
            });
        }
    }
}
