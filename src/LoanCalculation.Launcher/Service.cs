using LoanCalculation.Application;
using LoanCalculation.Domain;
using LoanCalculation.Domain.Dtos;
using LoanCalculation.Domain.Mappings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace LoanCalculation.Launcher
{
    public static class Service
    {
        public static IServiceProvider InitServiceProvider()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            return serviceCollection.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            ConfigureDefaultLoanConfig(serviceCollection);
            RegisterServices(serviceCollection);
            serviceCollection.AddAutoMapper(typeof(MappingsProfile));
        }

        private static void ConfigureDefaultLoanConfig(IServiceCollection serviceCollection)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json", false)
               .Build();

            serviceCollection.Configure<LoanTermDtos>(
                configuration.GetSection("DefaultLoanConfiguration")
            );
        }

        private static void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterDomainServices();
            serviceCollection.RegisterApplicationServices();
        }
    }
}
