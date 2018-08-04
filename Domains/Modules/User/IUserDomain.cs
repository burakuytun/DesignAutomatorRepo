using CrossCutting.Utils.PagedList;
using Domain.Domains.Modules.Base;
using Model.ViewModels;

namespace Domain.Domains.Modules.User
{
    public interface IUserDomain : IBaseDomain
    {
        PagedList<Model.Models.User> List(PagedListParameters parameters);

        Model.Models.User Select(long id);

        UserViewModel SelectViewModel(long id);

        UserViewModel SaveViewModel(UserViewModel user);
    }
}
