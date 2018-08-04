using Application.Modules.Modules.Base;
using CrossCutting.Mapping;
using CrossCutting.Utils.PagedList;
using Domain.Domains.Modules.User;
using Model.Models;
using Model.ViewModels;

namespace Application.Modules.Modules.UserModule
{
    public sealed class UserApplication : BaseApplication, IUserApplication
    {
        public UserApplication(IUserDomain user)
        {
            User = user;
        }

        private IUserDomain User { get; }

        public PagedList<User> List(PagedListParameters parameters)
        {
            return User.List(parameters);
        }

        public User Select(long id)
        {
            return User.Select(id);
        }

        public UserViewModel SelectUserViewModel(long id)
        {
            return User.SelectViewModel(id);
        }

        public UserViewModel Save(UserViewModel user)
        {
            return User.SaveViewModel(user);
        }
    }
}
