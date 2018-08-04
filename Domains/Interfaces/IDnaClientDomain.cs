using System;
using System.Collections.Generic;
using System.Text;
using Model.ViewModels;

namespace Domain.Domains.Interfaces
{
    public interface IDnaClientDomain : IBaseDomain
    {
        List<UserDnaClientViewModel> GetDnaClientByUser(int id);
        void UpdateUserDefaultDna(int userId, int newDefaultDnaId);
    }
}
