using System.Collections.Generic;
using System.Linq;
using Infrastructure.Database.Context;
using Infrastructure.Database.Interfaces;
using Infrastructure.EntityFrameworkCore;
using Model.Models;

namespace Infrastructure.Database.Repositories
{
    public class DnaClientRepository : EntityFrameworkCoreRepository<DnaClient>, IDnaClientRepository
    {
        public DnaClientRepository(DesignAutomatorContext context) : base(context)
        {

        }

        public IList<DnaClient> GetDnaClientById(List<int> id)
        {
            return List
            (
                where =>
                    (
                       id.Contains(where.Id)
                    )
            ).ToList();
        }
    }
}