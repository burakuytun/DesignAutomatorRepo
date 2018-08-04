using System.Collections.Generic;
using System.Linq;
using Application.Modules.Interfaces;
using Application.Modules.Modules.Base;
using Domain.Domains.Interfaces;
using Model.ViewModels;
using Newtonsoft.Json;

namespace Application.Modules.Modules.Dna
{
    public sealed class DnaApplication : BaseApplication, IDnaApplication
    {
        private IDnaDomain Dna { get; }
        private IDnaClientDomain DnaClientDomain { get; }

        public DnaApplication(IDnaDomain dna, IDnaClientDomain dnaClientDomain)
        {
            Dna = dna;
            DnaClientDomain = dnaClientDomain;
        }

        public List<DnaViewModel> GetDnaClientsByUserId(int userId)
        {
            //return Dna.GetDnaClientByUser(userId);
            return null;
        }

        public List<UserDnaClientViewModel> GetDnaClientsByUserIdForStorage(int userId)
        {
            var dnaList = DnaClientDomain.GetDnaClientByUser(userId);

            return dnaList.ToList();
        }

        public void UpdateUserDefaultDna(int userId, int newDefaultDnaId)
        {
            DnaClientDomain.UpdateUserDefaultDna(userId, newDefaultDnaId);
        }
    }
}
