using System.Collections.Generic;
using System.Linq;
using CrossCutting.Mapping;
using Domain.Domains.Interfaces;
using Domain.Domains.Modules.Base;
using Infrastructure.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using Model.Models.Validators;
using Model.ViewModels;

namespace Domain.Domains.Modules.Dna
{
    public class DnaClientDomain : BaseDomain, IDnaClientDomain
    {
        private IDatabaseUnitOfWork Database { get; }
        public IGenericUnitOfWork<UserDnaClient> UserDnaDatabase { get; }

        public DnaClientDomain(
            IDatabaseUnitOfWork database,
            IGenericUnitOfWork<UserDnaClient> userDnaDatabase)
        {
            Database = database;
            UserDnaDatabase = userDnaDatabase;
        }

        public List<UserDnaClientViewModel> GetDnaClientByUser(int id)
        {
            new CommonValidator().ValidateByIntegerFilter(id);

            var dnaClientList = UserDnaDatabase.GenericRepository.List(p => p.UserId == id, p => p.DnaClient).ToList();

            return new Mapper().Map<UserDnaClient, UserDnaClientViewModel>(dnaClientList).ToList();
        }

        public void UpdateUserDefaultDna(int userId, int newDefaultDnaId)
        {
            new CommonValidator().ValidateByIntegerFilter(userId);
            new CommonValidator().ValidateByIntegerFilter(newDefaultDnaId);

            var userDnaClients = UserDnaDatabase.GenericRepository.List(p => p.UserId == userId);

            foreach (var userDna in userDnaClients)
            {
                userDna.IsDefault = userDna.DnaClientId == newDefaultDnaId;

                UserDnaDatabase.GenericRepository.Update(userDna,userDna.Id);
            }

            UserDnaDatabase.SaveChanges();

            //var dnaClientList = UserDnaDatabase.GenericRepository.Update(PhoenixObject)

            //return new Mapper().Map<UserDnaClient, UserDnaClientViewModel>(dnaClientList).ToList();
        }
    }
}
