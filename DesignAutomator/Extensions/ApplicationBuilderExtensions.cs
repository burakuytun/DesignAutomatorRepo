using CrossCutting.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Web.DesignAutomator.Middlewares;

namespace Web.DesignAutomator.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        private static readonly IHostingEnvironment _environment = DependencyInjector.GetService<IHostingEnvironment>();

        public static void UseCorsCustom(this IApplicationBuilder application)
        {
            application.UseCors(cors => cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
        }

        public static void UseExceptionCustom(this IApplicationBuilder application)
        {
            if (_environment.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
                application.UseDatabaseErrorPage();
            }

            application.UseExceptionMiddleware();
        }

        public static void UseExceptionMiddleware(this IApplicationBuilder application)
        {
            application.UseMiddleware<ExceptionMiddleware>();
        }

        public static void UseHstsCustom(this IApplicationBuilder application)
        {
            if (!_environment.IsDevelopment())
            {
                application.UseHsts();
            }
        }

        public static void UseSpaCustom(this IApplicationBuilder application)
        {
            application.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (_environment.IsDevelopment())
                {
                    spa.UseAngularCliServer("start");
                }
            });
        }
    }
}
