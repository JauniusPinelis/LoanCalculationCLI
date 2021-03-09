using LoanCalculation.Domain.Dtos;

namespace LoanCalculation.Domain.Interfaces
{
    public interface IReportingService
    {
        string GeneratePaymentOverview(LoanParameterDtos loanParamaters);
    }
}
