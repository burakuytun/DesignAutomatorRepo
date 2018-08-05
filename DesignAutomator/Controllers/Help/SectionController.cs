using Application.Modules.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.DesignAutomator.Controllers.Help
{

    [Route("api/SectionService/[action]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private ISectionApplication SectionApplication { get; }
        public SectionController(ISectionApplication sectionApplication)
        {
            SectionApplication = sectionApplication;
        }

        [HttpGet]
        public IActionResult List()
        {
            var sections = SectionApplication.List();
            return Ok(sections);
        }

    }
}
