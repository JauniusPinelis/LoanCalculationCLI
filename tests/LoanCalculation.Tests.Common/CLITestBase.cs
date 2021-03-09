using LoanCalculation.Application.Services;
using LoanCalculation.Domain.Interfaces;
using LoanCalculation.Domain.Services;
using LoanCalculation.Domain.UnitTests;
using Moq;

namespace LoanCalculation.Tests.Common
{
    public class CLITestBase : ServiceTestBase
    {
        protected readonly ICLI Cli;

        public CLITestBase() : base()
        {
            var writer = new Mock<IWriter>();
            writer.Setup(w => w.WriteLine(It.IsAny<string>()));

            var validationService = new ValidationService();

            Cli = new CLI(writer.Object, ReportingService, validationService);
        }
    }
}
