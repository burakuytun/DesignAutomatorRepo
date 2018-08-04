using System.Collections.Generic;
using CrossCutting.Utils.Interfaces;
using Model.Models;

namespace Infrastructure.Database.Interfaces
{
    public interface IDnaRepository : IRepository<Dna>
    {
        Dna GetDnaClientByUser(string userName);
    }
}
