using System;
using System.Linq;

namespace LoanCalculation.Domain.Helpers
{
    public static class CalculationHelpers
    {
        public static decimal CalculateMonthlyPayment(decimal amount, decimal roi, int durationInMonths)
        {
            var amountDouble = (double)amount;
            var rate = (double)roi;

            var monthlyPayment = (amountDouble * rate * Math.Pow(1.0 + rate, durationInMonths)) / (Math.Pow(1.0 + rate, durationInMonths) - 1);

            return (decimal)monthlyPayment;
        }

        public static decimal CalculateInterestTotal(decimal amount, decimal monthlyPayment, int durationInMonths)
        {
            var totalAmountToPay = monthlyPayment * durationInMonths;
            return totalAmountToPay - amount;
        }

        public static decimal CalculateAdminFeesTotal(decimal amount, decimal percentageRate, decimal minFee)
        {
            var percentageFee = amount * percentageRate;

            return new decimal[] { percentageFee, minFee }.Min();
        }

        public static double CalculateAPR(decimal amount, decimal interestTotal, decimal fees, int durationInMonths)
        {
            var termsInDays = durationInMonths / 12M * 365;
            return (double)((interestTotal + fees) / amount / termsInDays * 365 * 100M);
        }
    }
}
