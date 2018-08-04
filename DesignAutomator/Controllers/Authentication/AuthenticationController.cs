using Application.Modules.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Models.Authentication;

namespace Web.DesignAutomator.Controllers.Authentication
{
    [Route("api/AuthenticationService")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationApplication Authentication { get; }

        public AuthenticationController(IAuthenticationApplication authentication)
        {
            Authentication = authentication;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public string Authenticate(AuthenticationModel authentication)
        {
            return Authentication.Authenticate(authentication);
        }
    }
}