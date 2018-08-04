using Application.Modules.Interfaces;
using Application.Modules.Modules.Base;
using Domain.Domains.Interfaces;
using Model.Models.Authentication;

namespace Application.Modules.Modules.Authentication
{
	public sealed class AuthenticationApplication : BaseApplication, IAuthenticationApplication
	{
	    private IAuthenticationDomain Authentication { get; }

        public AuthenticationApplication(IAuthenticationDomain authentication)
		{
			Authentication = authentication;
		}

		public string Authenticate(AuthenticationModel authentication)
		{
			return Authentication.Authenticate(authentication);
		}
	}
}
