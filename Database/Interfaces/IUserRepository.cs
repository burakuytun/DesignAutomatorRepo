using CrossCutting.Utils.Interfaces;
using Model.Models;
using Model.Models.Authentication;

namespace Infrastructure.Database.Interfaces
{
	public interface IUserRepository : IRepository<User>
	{
	    AuthenticatedModel Authenticate(AuthenticationModel authentication);
    }
}
