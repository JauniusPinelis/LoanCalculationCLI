using LoanCalculation.Domain.Dtos;
using System;

namespace LoanCalculation.Domain.Extensions
{
    public static class StringArrayExtensions
    {
        public static LoanParameterDtos ConvertToLoanParameters(this string[] args)
        {
            return new LoanParameterDtos()
            {
                Amount = Decimal.Parse(args[0]),
                DurationInYears = Int32.Parse(args[1])
            };
        }
    }
}
