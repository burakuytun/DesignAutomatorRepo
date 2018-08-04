using System.Security.Claims;
using Application.Modules.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Model.Models.Authentication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Web.DesignAutomator.Controllers.Dna
{
    [Route("api/DnaService/[action]")]
    [ApiController]
    public class DnaController : ControllerBase
    {
        private IDnaApplication DnaApplication { get; }

        public DnaController(IDnaApplication dnaApplication)
        {
            DnaApplication = dnaApplication;
        }

        [HttpGet(Name = "GetUserDnaForStorage")]
        public IActionResult GetUserDnaForStorage()
        {
            AuthenticatedModel loggedInUser =
                JsonConvert.DeserializeObject<AuthenticatedModel>
                    (User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return new OkObjectResult(DnaApplication.GetDnaClientsByUserIdForStorage((int)loggedInUser.Id));
        }

        [HttpPost]
        public IActionResult UpdateUserDefaultDna([FromBody]int dnaId)
        {
            AuthenticatedModel loggedInUser =
                JsonConvert.DeserializeObject<AuthenticatedModel>
                    (User.FindFirst(ClaimTypes.NameIdentifier).Value);

            DnaApplication.UpdateUserDefaultDna((int)loggedInUser.Id, dnaId);

            return new OkResult();

        }
    }
}
