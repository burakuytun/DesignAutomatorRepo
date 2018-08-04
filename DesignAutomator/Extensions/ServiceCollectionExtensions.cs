using CrossCutting.DependencyInjection;
using CrossCutting.Security.JsonWebToken;
using Infrastructure.Database.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

//using CrossCutting.Security;

namespace Web.DesignAutomator.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAuthenticationCustom(this IServiceCollection services)
        {
            var jsonWebToken = DependencyInjector.GetService<IJsonWebToken>();

            void JwtBearer(JwtBearerOptions jwtBearer)
            {
                jwtBearer.RequireHttpsMetadata = false;
                jwtBearer.SaveToken = true;
                jwtBearer.TokenValidationParameters = jsonWebToken.TokenValidationParameters;
            }

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearer);
        }

        public static void AddDependencyInjectionCustom(this IServiceCollection services, IConfiguration configuration)
        {
            DependencyInjector.RegisterServices(services);
            DependencyInjector.AddDbContext<DesignAutomatorContext>(configuration.GetConnectionString("DefaultConnection"));
        }

        public static void AddSpaStaticFilesCustom(this IServiceCollection services)
        {
            services.AddSpaStaticFiles(spa => spa.RootPath = "ClientApp/dist");
        }

        public static void AddMvcCustom(this IServiceCollection services)
        {
            void Mvc(MvcOptions mvc)
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                mvc.Filters.Add(new AuthorizeFilter(policy));

            }

            void Json(MvcJsonOptions json)
            {
                json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                json.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            }

            services.AddMvc(Mvc).AddJsonOptions(Json)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
    }
}
