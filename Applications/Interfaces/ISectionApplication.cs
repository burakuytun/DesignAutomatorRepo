using System.Collections.Generic;
using CrossCutting.Utils.PagedList;
using Model.ViewModels.Help;

namespace Application.Modules.Interfaces
{
    public interface ISectionApplication : IBaseApplication
    {
        List<SectionViewModel> List(PagedListParameters parameters);
        List<SectionViewModel> ListWithQuestions();
        long Count();
    }
}
