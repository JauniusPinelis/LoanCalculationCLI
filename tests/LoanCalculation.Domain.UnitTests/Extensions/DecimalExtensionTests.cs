using FluentAssertions;
using LoanCalculation.Domain.Extensions;
using Xunit;

namespace LoanCalculation.Domain.UnitTests.Extensions
{
    public class DecimalExtensionTests
    {
        [Fact]
        public void ToCurrencyString_GivenDecimal_ConvertsToDanishCurrency()
        {
            var decimalValue = 10000M;

            var currencyValue = decimalValue.ToCurrencyString();

            currencyValue.Should().Contain(Constants.DefaultCurrencyCode);
        }

        [Fact]
        public void ToCurrencyString_GivenDecimal_AppliesRoundingAndDefaultFormatting()
        {
            var decimalValue = 10000.0333M;

            var currencyValue = decimalValue.ToCurrencyString();

            currencyValue.Should().Be("10.000,03 kr.");
        }
    }
}
