using AutoMapper;
using LoanCalculation.Domain.Dtos;
using LoanCalculation.Domain.Extensions;
using LoanCalculation.Domain.Helpers;
using LoanCalculation.Domain.Interfaces;
using LoanCalculation.Domain.Models;
using Microsoft.Extensions.Options;

namespace LoanCalculation.Domain.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly LoanTermDtos _loanTerms;
        private readonly IMapper _mapper;

        public CalculationService(IOptionsMonitor<LoanTermDtos> configuration, IMapper mapper)
        {
            _loanTerms = configuration.CurrentValue ?? throw new System.ArgumentNullException(nameof(configuration));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        public GeneratedLoanInfo GenerateLoanInfo(LoanParameterDtos loanParametersDto)
        {
            var loanConfig = _mapper.MergeInto<LoanConfiguration>(loanParametersDto, _loanTerms);

            var monthlyPayment = CalculationHelpers.CalculateMonthlyPayment(
                    amount: loanConfig.Amount,
                    roi: loanConfig.AnnualInterestRate,
                    durationInMonths: loanConfig.DurationInMonths);

            var interestTotal = CalculationHelpers.CalculateInterestTotal(
                    amount: loanConfig.Amount,
                    monthlyPayment: monthlyPayment,
                    durationInMonths: loanConfig.DurationInMonths);

            var administrationFee = CalculationHelpers.CalculateAdminFeesTotal(
                    amount: loanConfig.Amount,
                    percentageRate: loanConfig.PercentageAdminFee,
                    minFee: loanConfig.MaxAdminFee);

            var annualPercentageRate = CalculationHelpers.CalculateAPR(
                    amount: loanConfig.Amount,
                    interestTotal: interestTotal,
                    fees: administrationFee,
                    durationInMonths: loanConfig.DurationInMonths
                );

            return new GeneratedLoanInfo()
            {
                MonthlyPayment = monthlyPayment,
                InterestTotal = interestTotal,
                AdministrationFee = administrationFee,
                AnnualPercentageRate = annualPercentageRate
            };
        }
    }
}
