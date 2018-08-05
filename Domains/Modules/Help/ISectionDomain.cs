using System.Collections.Generic;
using CrossCutting.Utils.PagedList;
using Model.Models.Help;

namespace Domain.Domains.Modules.Help
{
    public interface ISectionDomain
    {
        IList<Section> ListWithQuestions();
        IList<Section> List(PagedListParameters parameters);
        long Count();
    }
}
