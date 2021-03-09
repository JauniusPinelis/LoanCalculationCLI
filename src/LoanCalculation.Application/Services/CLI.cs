using LoanCalculation.Application.Enums;
using LoanCalculation.Domain.Extensions;
using LoanCalculation.Domain.Interfaces;
using System;

namespace LoanCalculation.Application.Services
{
    public class CLI : ICLI
    {
        private readonly IWriter _writer;
        private readonly IReportingService _reportingService;
        private readonly IValidationService _validationService;

        public CLI(IWriter writer, IReportingService reportingService, IValidationService validationService)
        {
            _writer = writer ?? throw new ArgumentNullException(nameof(writer));
            _reportingService = reportingService ?? throw new ArgumentNullException(nameof(reportingService));
            _validationService = validationService ?? throw new ArgumentNullException(nameof(validationService));
        }

        public int Run(string[] args)
        {
            try
            {
                bool isValid = _validationService.Validate(args);

                if (!isValid)
                {
                    throw new FormatException();
                }

                var loanParameters = args.ConvertToLoanParameters();

                var paymentOverview = _reportingService.GeneratePaymentOverview(loanParameters);

                _writer.WriteLine(paymentOverview);

                return (int)ExitCode.Success;

            }
            catch (FormatException)
            {
                _writer.WriteLine("Validating input parameters failed, please specify Loan amount and the duration of loan in years");
                _writer.WriteLine("For example: dotnet Run 50000 10 ");
                return (int)ExitCode.Error;
            }
        }
    }
}
