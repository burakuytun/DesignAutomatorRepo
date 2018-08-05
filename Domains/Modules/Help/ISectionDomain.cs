using System;
using System.Collections.Generic;
using System.Text;
using Model.Models.Help;

namespace Domain.Domains.Modules.Help
{
    public interface ISectionDomain
    {
        IList<Section> List();
    }
}
