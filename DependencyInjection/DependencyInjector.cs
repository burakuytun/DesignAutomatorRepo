using System;
using Application.Modules.Interfaces;
using Application.Modules.Modules.Authentication;
using Application.Modules.Modules.AutomationFunctions;
using Application.Modules.Modules.Dna;
using Application.Modules.Modules.FileUpload;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CrossCutting.Logging;
using Application.Modules.Modules.UserModule;
using CrossCutting.Mapping;
using CrossCutting.Security.Criptography;
using CrossCutting.Security.Hash;
using CrossCutting.Security.JsonWebToken;
using Domain.Domains.Interfaces;
using Domain.Domains.Modules.Authentication;
using Domain.Domains.Modules.Dna;
using Domain.Domains.Modules.User;
using Infrastructure.Database.Interfaces;
using Infrastructure.Database.Repositories;
using Infrastructure.Database.UnitOfWork;

namespace CrossCutting.DependencyInjection
{
    public static class DependencyInjector
    {
        private static IServiceProvider ServiceProvider { get; set; }

        private static IServiceCollection Services { get; set; }

        public static void AddDbContext<T>(string connectionString) where T : DbContext
        {
            Services.AddDbContextPool<T>(options => options.UseSqlServer(connectionString));
        }

        public static void AddDbContextInMemoryDatabase<T>() where T : DbContext
        {
            Services.AddDbContextPool<T>(options => options.UseInMemoryDatabase(typeof(T).Name));
            GetService<T>().Database.EnsureCreated();
        }

        public static T GetService<T>()
        {
            Services = Services ?? RegisterServices();
            ServiceProvider = ServiceProvider ?? Services.BuildServiceProvider();
            return ServiceProvider.GetService<T>();
        }

        public static IServiceCollection RegisterServices()
        {
            return RegisterServices(new ServiceCollection());
        }

        public static IServiceCollection RegisterServices(IServiceCollection services)
        {
            Services = services;

            //// Solution.Application.Applications
            Services.AddScoped<IAuthenticationApplication, AuthenticationApplication>();
            Services.AddScoped<IUserApplication, UserApplication>();
            Services.AddScoped<IDnaApplication, DnaApplication>();
            Services.AddScoped<IFileUploadApplication, FileUploadApplication>();
            Services.AddScoped<IAutomationFunctionsApplication, AutomationFunctionsApplication>();
            

            //// Solution.CrossCutting
            Services.AddScoped<ICriptography, Criptography>();
            Services.AddScoped<IHash, Hash>();
            Services.AddScoped<IJsonWebToken, JsonWebToken>();
            Services.AddScoped<ILogger, Logger>();
            Services.AddScoped<IMapper, Mapper>(); //this can be used for testing

            //// Solution.Domain.Domains
            Services.AddScoped<IAuthenticationDomain, AuthenticationDomain>();
            Services.AddScoped<IUserDomain, UserDomain>();
            Services.AddScoped<IDnaDomain, DnaDomain>();
            Services.AddScoped<IDnaClientDomain, DnaClientDomain>();

            //// Solution.Infrastructure.Database
            Services.AddScoped<IDatabaseUnitOfWork, DatabaseUnitOfWork>();
            Services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));
            Services.AddScoped<IUserRepository, UserRepository>();
            Services.AddScoped<IDnaRepository, DnaRepository>();
            Services.AddScoped<IDnaClientRepository, DnaClientRepository>();
            Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return Services;
        }
    }
}
