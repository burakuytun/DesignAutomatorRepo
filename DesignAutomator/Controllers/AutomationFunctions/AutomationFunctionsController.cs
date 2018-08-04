using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AgileObjects.AgileMapper.Extensions;
using Application.Modules.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Models.Authentication;
using Model.Types.QueryParams;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Web.DesignAutomator.Controllers.AutomationFunctions
{
    [Route("api/AutomationFunctionsService/[action]")]
    [ApiController]
    public class AutomationFunctionsController : ControllerBase
    {
        private IAutomationFunctionsApplication AutomationFunctionsApplication { get; }

        public AutomationFunctionsController(IAutomationFunctionsApplication automationFunctionsApplication)
        {
            AutomationFunctionsApplication = automationFunctionsApplication;
        }

        [HttpPost]
        public IActionResult RunAutomationFunction([FromBody]JObject data)
        {
            FunctionParam functionParams = data.ToObject<FunctionParam>();

            AuthenticatedModel loggedInUser =
                JsonConvert.DeserializeObject<AuthenticatedModel>
                    (User.FindFirst(ClaimTypes.NameIdentifier).Value);

            AutomationFunctionsApplication.RunFunction(loggedInUser, functionParams.FileList, functionParams.FunctionId, functionParams.DnaId);

            return new OkResult();
        }
    }
}