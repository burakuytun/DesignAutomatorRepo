using Model.Models.Authentication;

namespace Application.Modules.Interfaces
{
	public interface IAuthenticationApplication : IBaseApplication
	{
		string Authenticate(AuthenticationModel authentication);
	}
}
