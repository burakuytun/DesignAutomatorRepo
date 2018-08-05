using System.Collections.Generic;
using Application.Modules.Interfaces;
using Application.Modules.Modules.Base;
using CrossCutting.Mapping;
using CrossCutting.Utils.PagedList;
using Domain.Domains.Modules.Help;
using Model.ViewModels.Help;

namespace Application.Modules.Modules.Help
{
    public class SectionApplication:BaseApplication,ISectionApplication
    {
        private ISectionDomain Section{ get; }

        public SectionApplication(ISectionDomain section)
        {
            Section = section;
        }
        public List<SectionViewModel> List(PagedListParameters parameters)
        {
            var sections = Section.List(parameters);

            return new Mapper().Map<List<SectionViewModel>>(sections);
        }

        public List<SectionViewModel> ListWithQuestions()
        {
            var sections = Section.ListWithQuestions();

            return new Mapper().Map<List<SectionViewModel>>(sections);
        }

        public long Count()
        {
            return Section.Count();
        }
    }
}
