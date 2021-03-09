using System;
using System.Globalization;

namespace LoanCalculation.Domain.Extensions
{
    public static class DecimalExtensions
    {
        public static string ToCurrencyString(this decimal value)
        {
            return decimal.Round(value, Constants.DecimalPlacesRound, MidpointRounding.AwayFromZero)
                .ToString("c", new CultureInfo(Constants.DefaultCultureCode));
        }
    }
}
