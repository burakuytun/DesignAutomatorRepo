using System.Collections.Generic;
using Model.Models.Authentication;

namespace Application.Modules.Interfaces
{
    public interface IAutomationFunctionsApplication : IBaseApplication
    {
        string RunFunction(AuthenticatedModel user, List<string> fileList, short functionId, short dnaClientId);
    }
}
