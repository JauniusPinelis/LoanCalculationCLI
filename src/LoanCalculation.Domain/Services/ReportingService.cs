using LoanCalculation.Domain.Dtos;
using LoanCalculation.Domain.Interfaces;
using System;

namespace LoanCalculation.Domain.Services
{
    public class ReportingService : IReportingService
    {
        private readonly ICalculationService _loanCalculationService;

        public ReportingService(ICalculationService loanCalculationService)
        {
            _loanCalculationService = loanCalculationService ?? throw new ArgumentNullException(nameof(loanCalculationService));
        }

        public string GeneratePaymentOverview(LoanParameterDtos loanParamaters)
        {
            //var generatedLoanInfo = _loanCalculationService.GenerateLoanInfo(loanParamaters);

            return generatedLoanInfo.ToString();
        }
    }
}
