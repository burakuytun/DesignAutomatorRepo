using System;
using Model.Models.Authentication;

namespace Web.DesignAutomator.Utils
{
    public class WebUtil
    {
        public static AuthenticatedModel GetLoggedInUser(dynamic claims)
            =>
                new AuthenticatedModel
                {
                    Id = claims.id.Value ?? 0,
                    Name = claims.name.Value ?? String.Empty,
                    Surname = claims.surname.Value ?? String.Empty,
                    UserName = claims.username.Value ?? String.Empty,
                    Roles = claims.roles.Value ?? null
                };
    }
}

