using System.Linq;
using CrossCutting.Security.Hash;
using CrossCutting.Security.JsonWebToken;
using Domain.Domains.Interfaces;
using Domain.Domains.Modules.Base;
using Infrastructure.Database.Interfaces;
using Model.Models.Authentication;
using Model.Models.Validators;
using Newtonsoft.Json;

namespace Domain.Domains.Modules.Authentication
{
    public sealed class AuthenticationDomain : BaseDomain, IAuthenticationDomain
    {
        private IDatabaseUnitOfWork Database { get; }
        private IHash Hash { get; }
        private IJsonWebToken JsonWebToken { get; }

        public AuthenticationDomain(
            IDatabaseUnitOfWork database,
            IHash hash,
            IJsonWebToken jsonWebToken)
        {
            Database = database;
            Hash = hash;
            JsonWebToken = jsonWebToken;
        }

        public string Authenticate(AuthenticationModel authentication)
        {
            new AuthenticationValidator().ValidateThrowException(authentication);

            SetHash(authentication);

            var authenticated = Database.UserRepository.Authenticate(authentication);

            new AuthenticatedValidator().ValidateThrowException(authenticated);

            return GetJwt(authenticated);
        }

        private string GetJwt(AuthenticatedModel authenticated)
        {
            var roles = authenticated.Roles.Select(role => role.ToString()).ToArray();
            return JsonWebToken.Encode(JsonConvert.SerializeObject(authenticated), roles);
        }

        private void SetHash(AuthenticationModel authentication)
        {
            authentication.Password = Hash.Create(authentication.Password);
        }
    }
}
