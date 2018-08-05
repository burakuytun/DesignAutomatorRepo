using System.Collections.Generic;
using System.Linq;
using CrossCutting.Utils.PagedList;
using Domain.Domains.Modules.Base;
using Infrastructure.Database.Interfaces;
using Model.Models.Help;

namespace Domain.Domains.Modules.Help
{
    public class SectionDomain:BaseDomain,ISectionDomain
    {

        public SectionDomain(IDatabaseUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        private IDatabaseUnitOfWork UnitOfWork { get; }

        public IList<Section> ListWithQuestions()
        {
            return UnitOfWork.SectionRepository.List(p=>p.Questions).ToList();
        }

        public IList<Section> List(PagedListParameters parameters)
        {
            return UnitOfWork.SectionRepository.List().ToList();
        }

        public long Count()
        {
            return UnitOfWork.SectionRepository.Count();
        }
    }
}
