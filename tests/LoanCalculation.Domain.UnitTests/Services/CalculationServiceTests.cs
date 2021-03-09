using FluentAssertions;
using LoanCalculation.Domain.Dtos;
using Xunit;

namespace LoanCalculation.Domain.UnitTests.Services
{
    public class CalculationServiceTests : ServiceTestBase
    {
        [Fact]
        public void CalculatePayment_GivenDefaultConfiguration_ReturnsCorrectAnswers()
        {
            var loanParameters = new LoanParameterDtos();
            loanParameters.Amount = 500000M;
            loanParameters.DurationInYears = 10;

            var payment = CalculationService.GenerateLoanInfo(loanParameters);

            payment.MonthlyPayment.Should().BeApproximately(5303.28M, 0.01M);
            payment.InterestTotal.Should().BeApproximately(136393.09M, 0.01M);
            payment.AdministrationFee.Should().BeApproximately(5000, 0.01M);
        }
    }
}
