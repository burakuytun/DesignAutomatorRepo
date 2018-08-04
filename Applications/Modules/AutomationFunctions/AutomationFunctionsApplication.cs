using System;
using System.Collections.Generic;
using Application.Modules.Interfaces;
using Application.Modules.Modules.Base;
using Microsoft.AspNetCore.Hosting;
using Model.Models.Authentication;

namespace Application.Modules.Modules.AutomationFunctions
{
    public class AutomationFunctionsApplication : BaseApplication, IAutomationFunctionsApplication
    {
        private IHostingEnvironment HostingEnvironment { get; }

        public AutomationFunctionsApplication(IHostingEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
        }

        public string RunFunction(AuthenticatedModel user, List<string> fileList, short functionId, short dnaClientId)
        {
            var a = HostingEnvironment.ContentRootPath;

            return "";
        }
    }
}
