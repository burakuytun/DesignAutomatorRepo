using Application.Modules.Interfaces;
using CrossCutting.Utils.PagedList;
using Model.Models;
using Model.ViewModels;

namespace Application.Modules.Modules.UserModule
{
    public interface IUserApplication : IBaseApplication
	{
		PagedList<User> List(PagedListParameters parameters);

		User Select(long id);

	    UserViewModel SelectUserViewModel(long id);

	    UserViewModel Save(UserViewModel user);
	}
}
