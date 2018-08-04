using System;
using System.Collections.Generic;
using Infrastructure.Database.Context;
using Infrastructure.Database.Interfaces;
using Infrastructure.EntityFrameworkCore;
using Model.Models;
using Model.Models.Authentication;

namespace Infrastructure.Database.Repositories
{
    public sealed class UserRepository : EntityFrameworkCoreRepository<User>, IUserRepository
    {
        public UserRepository(DesignAutomatorContext context) : base(context)
        {
        }

        public AuthenticatedModel Authenticate(AuthenticationModel authentication)
        {
            if (!authentication.isActiveDomainAccount)
            {
                return SingleOrDefaultResult
                (
                    where =>
                        (
                            where.UserName.Equals(authentication.UserName)
                            && where.Password.Equals(authentication.Password)
                            && where.IsActive.Value
                        ),
                    select => new AuthenticatedModel
                    {
                        Id = select.Id,
                        Roles = GetRoles(select),
                        UserName = select.UserName,
                        Name = select.Name,
                        Surname = select.Surname,
                        ProfilePicture = select.ProfilePicture
                    }
                );
            }

            return null;
        }

        private int[] GetRoles(User user)
        {
            //normal user
            var roles = new List<int> { 1 };
            if (user.Dnamanager) roles.Add(2);
            if (user.IsAdmin) roles.Add(3);

            return roles.ToArray();
        }
    }
}
