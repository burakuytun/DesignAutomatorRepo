using System;
using System.Collections.Generic;
using System.Text;
using Model.ViewModels.Help;

namespace Application.Modules.Interfaces
{
    public interface ISectionApplication
    {
        List<SectionViewModel> List();
    }
}
