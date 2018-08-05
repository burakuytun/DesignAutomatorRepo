using Application.Modules.Interfaces;
using CrossCutting.Utils.PagedList;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModels;

namespace Web.DesignAutomator.Controllers.Help
{

    [Route("api/SectionService")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private ISectionApplication SectionApplication { get; }
        public SectionController(ISectionApplication sectionApplication)
        {
            SectionApplication = sectionApplication;
        }

        [HttpGet]
        [Route("list-with-questions")]
        public IActionResult ListWithQuestions()
        {
            var sections = SectionApplication.ListWithQuestions();
            return Ok(sections);
        }

        [HttpGet]
        [Route("list/{index:int}")]
        public IActionResult List(int index)
        {
            var parameters = new PagedListParameters{Page = new Page{Index = index,Size = 10}};
            var sections = SectionApplication.List(parameters);
            return Ok(sections);
        }

        [HttpGet]
        [Route("count")]
        public IActionResult Count()
        {
            var count = SectionApplication.Count();
            return Ok(new CountViewModel {Count = count});
        }

    }
}
