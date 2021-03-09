using AutoMapper;
using LoanCalculation.Domain.Dtos;
using LoanCalculation.Domain.Interfaces;
using LoanCalculation.Domain.Mappings;
using LoanCalculation.Domain.Models;
using LoanCalculation.Domain.Services;
using Microsoft.Extensions.Options;
using Moq;

namespace LoanCalculation.Domain.UnitTests
{
    public abstract class ServiceTestBase
    {
        protected readonly ICalculationService CalculationService;
        protected readonly IReportingService ReportingService;

        public ServiceTestBase()
        {
            var configuration = new LoanTermDtos();

            configuration.AnnualInterestRate = 5;
            configuration.AdministrationFee = new AdministrationFee()
            {
                Percentage = 1,
                MinimalAmount = 10000,
            };

            var configurationMonitor = new Mock<IOptionsMonitor<LoanTermDtos>>();
            configurationMonitor.Setup(c => c.CurrentValue).Returns(configuration);

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingsProfile());
            });
            var mapper = mapperConfig.CreateMapper();


            CalculationService = new CalculationService(configurationMonitor.Object, mapper);

            ReportingService = new ReportingService(CalculationService);
        }
    }
}
