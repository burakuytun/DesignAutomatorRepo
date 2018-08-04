using System.Collections.Generic;
using System.Linq;
using CrossCutting.Mapping;
using CrossCutting.Security.Hash;
using Domain.Domains.Interfaces;
using Domain.Domains.Modules.Base;
using Infrastructure.Database.Interfaces;
using Model.Models.Validators;
using Model.ViewModels;
using Newtonsoft.Json;

namespace Domain.Domains.Modules.Dna
{
    public class DnaDomain : BaseDomain, IDnaDomain
    {
        private IDatabaseUnitOfWork Database { get; }
        
        public DnaDomain(
            IDatabaseUnitOfWork database)
        {
            Database = database;
        }

        //public DnaViewModel GetDnaClientByUser(string userName)
        //{
        //    new DnaValidator().ValidateGetByUsername(userName);

        //    var dnaClient = Database.DnaRepository.GetDnaClientByUser(userName);

        //    return new Mapper().Map<DnaViewModel>(dnaClient);
        //}       
    }
}
