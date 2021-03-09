using FluentAssertions;
using LoanCalculation.Domain.Dtos;
using Xunit;

namespace LoanCalculation.Domain.UnitTests.Services
{
    public class ReportingServiceTests : ServiceTestBase
    {

        [Fact]
        public void GeneratePaymentOverview_GivenCorrectParameters_ContainsAttributeNames()
        {
            var loanParameters = new LoanParameterDtos();
            loanParameters.Amount = 500000M;
            loanParameters.DurationInYears = 10;

            var reportDetailNames = new string[]
            {
                "Monthly Payment",
                "Administration Fee",
                "Interest Total",
                "Annual Percentage Rate"
            };

            var paymentOverview = ReportingService.GeneratePaymentOverview(loanParameters);

            paymentOverview.Should().ContainAll(reportDetailNames);
        }
        [Fact]
        public void GeneratePaymentOverview_GivenCorrectParameters_ContainsCurrency()
        {
            var loanParameters = new LoanParameterDtos();
            loanParameters.Amount = 500000M;
            loanParameters.DurationInYears = 10;

            var paymentOverview = ReportingService.GeneratePaymentOverview(loanParameters);

            paymentOverview.Should().Contain($"{Constants.DefaultCurrencyCode}.");
        }
    }
}
