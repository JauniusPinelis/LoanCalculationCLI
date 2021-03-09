using FluentAssertions;
using LoanCalculation.Domain.Helpers;
using Xunit;

namespace LoanCalculation.Domain.UnitTests
{

    public class CalculationHelpersTests
    {
        [Theory]
        [InlineData(500000, 5 / 12.0 / 100.00, 120, 5303.28)]
        [InlineData(500000, 0.004166666666, 120, 5303.28)]
        [InlineData(10000, 10 / 12.0 / 100.0, 12, 879.16)]
        public void CalculateMonthlyPayment_GivenParameters_CalculatesMontlyPayment(decimal amount, decimal roi,
            int years, decimal monthlyPayment)
        {
            var calculatedMonthlyPayment = CalculationHelpers.CalculateMonthlyPayment(amount, roi, years);

            calculatedMonthlyPayment.Should().BeApproximately(monthlyPayment, 0.01M);
        }

        [Theory]
        [InlineData(500000, 5303.275761953777, 120, 136393.09)]
        [InlineData(10000, 188.71, 60, 1322.60)]
        public void CalculateInterestTotal_GivenParameters_CalculatesInterestTotal(decimal amount, decimal monthlyPayment,
            int termsInMonths, decimal interestTotal)
        {
            var calculatedInterestTotal = CalculationHelpers.CalculateInterestTotal(amount, monthlyPayment, termsInMonths);

            calculatedInterestTotal.Should().BeApproximately(interestTotal, 0.01M);
        }

        [Fact]
        public void CalculateAPR_GivenParameters_CalculatesAPR()
        {
            var loanAmount = 20;
            var interestTotal = 2;
            var fees = 3;
            var durationInMonths = 12;

            var apr = CalculationHelpers.CalculateAPR(loanAmount, interestTotal, fees, durationInMonths);

            apr.Should().BeApproximately(25D, 0.01D);
        }

        [Fact]
        public void CalculateAdminFeesTotal_GivenLowerPercentageFee_AdminFeeShouldBeBelowMax(
            )
        {
            var loanAmount = 500000M;
            var percentageRate = 0.01M;
            var maxAdminFee = 100000;

            var adminFee = CalculationHelpers.CalculateAdminFeesTotal(loanAmount, percentageRate, maxAdminFee);

            adminFee.Should().BeLessThan(maxAdminFee);
        }

        [Fact]
        public void CalculateAdminFeesTotal_GivenLowerMaxFee_AdminFeeShouldBeMaxFee()
        {
            var loanAmount = 500000M;
            var percentageRate = 0.01M;
            var maxAdminFee = 100;

            var adminFee = CalculationHelpers.CalculateAdminFeesTotal(loanAmount, percentageRate, maxAdminFee);

            adminFee.Should().Be(maxAdminFee);
        }

    }
}
