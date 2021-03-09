using LoanCalculation.Application.Services;
using LoanCalculation.Domain.Interfaces;
using LoanCalculation.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LoanCalculation.Domain
{
    public static class DependencyInjection
    {
        public static void RegisterDomainServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICalculationService, CalculationService>();
            serviceCollection.AddScoped<IReportingService, ReportingService>();
            serviceCollection.AddScoped<IValidationService, ValidationService>();
        }
    }
}
