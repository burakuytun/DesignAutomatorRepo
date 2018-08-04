using System.Collections.Generic;
using System.Linq;
using Infrastructure.Database.Context;
using Infrastructure.Database.Interfaces;
using Infrastructure.EntityFrameworkCore;
using Model.Models;

namespace Infrastructure.Database.Repositories
{
    public class DnaRepository : EntityFrameworkCoreRepository<Dna>, IDnaRepository
    {
        public DnaRepository(DesignAutomatorContext context) : base(context)
        {

        }

        public Dna GetDnaClientByUser(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
                return SingleOrDefault
                (
                    where =>
                        (
                            where.Value.Equals(userName)
                        )
                );

            return null;
        }
    }
}