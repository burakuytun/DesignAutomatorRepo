using System.Collections.Generic;
using CrossCutting.Utils.PagedList;
using Domain.Domains.Modules.Base;
using Infrastructure.Database.Interfaces;
using Model.Models.Help;
using Model.ViewModels.Help;

namespace Domain.Domains.Modules.Help
{
    public class SectionDomain:BaseDomain,ISectionDomain
    {

        public SectionDomain(IDatabaseUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        private IDatabaseUnitOfWork UnitOfWork { get; }

        public IList<Section> List()
        {
            return UnitOfWork.SectionRepository.ListwithQuestions();
        }

    }
}
