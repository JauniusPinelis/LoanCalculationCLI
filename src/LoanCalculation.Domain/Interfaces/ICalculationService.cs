using LoanCalculation.Domain.Dtos;
using LoanCalculation.Domain.Models;

namespace LoanCalculation.Domain.Interfaces
{
    public interface ICalculationService
    {
        GeneratedLoanInfo GenerateLoanInfo(LoanParameterDtos loanParameters);
    }
}
