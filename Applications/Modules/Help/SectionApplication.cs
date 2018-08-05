using System.Collections.Generic;
using Application.Modules.Interfaces;
using Application.Modules.Modules.Base;
using CrossCutting.Mapping;
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
        public List<SectionViewModel> List()
        {
            var sections = Section.List();

            return new Mapper().Map<List<SectionViewModel>>(sections);
        }
    }
}
