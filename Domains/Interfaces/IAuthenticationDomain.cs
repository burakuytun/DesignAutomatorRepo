using Model.Models.Authentication;

namespace Domain.Domains.Interfaces
{
	public interface IAuthenticationDomain : IBaseDomain
	{
		string Authenticate(AuthenticationModel authentication);
	}
}
