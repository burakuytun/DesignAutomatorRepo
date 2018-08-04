using System.Collections.Generic;
using Model.ViewModels;

namespace Application.Modules.Interfaces
{
    public interface IDnaApplication : IBaseApplication
    {
        List<DnaViewModel> GetDnaClientsByUserId(int userId);
        List<UserDnaClientViewModel> GetDnaClientsByUserIdForStorage(int userId);
        void UpdateUserDefaultDna(int userId, int newDefaultDnaId);
    }
}
