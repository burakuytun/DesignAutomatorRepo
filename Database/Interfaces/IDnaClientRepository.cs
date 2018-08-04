using System.Collections.Generic;
using CrossCutting.Utils.Interfaces;
using Model.Models;

namespace Infrastructure.Database.Interfaces
{
    public interface IDnaClientRepository : IRepository<DnaClient>
    {
        IList<DnaClient> GetDnaClientById(List<int> id);
    }
}
