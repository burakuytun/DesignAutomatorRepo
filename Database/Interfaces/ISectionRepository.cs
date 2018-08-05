using System.Collections.Generic;
using Model.Models.Help;

namespace Infrastructure.Database.Interfaces
{
    public interface ISectionRepository
    {
        IList<Section> ListwithQuestions();
    }
}
