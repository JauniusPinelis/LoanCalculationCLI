using LoanCalculation.Application.Services;
using LoanCalculation.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LoanCalculation.Application
{
    public static class DependencyInjection
    {
        public static void RegisterApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IWriter, ConsoleWriter>();
            serviceCollection.AddScoped<ICLI, CLI>();
        }
    }
}
