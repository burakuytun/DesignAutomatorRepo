using System.Collections.Generic;
using System.Linq;
using Infrastructure.Database.Context;
using Infrastructure.Database.Interfaces;
using Infrastructure.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories
{
    public class SectionRepository : EntityFrameworkCoreRepository<Model.Models.Help.Section>,ISectionRepository
    {
        public SectionRepository(DesignAutomatorContext context) : base(context)
        {
        }

        public IList<Model.Models.Help.Section> ListwithQuestions()
        {
            return List(p=>p.Questions).ToList();
        }
    }
}
