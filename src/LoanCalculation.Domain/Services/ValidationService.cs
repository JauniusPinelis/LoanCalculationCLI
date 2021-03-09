using LoanCalculation.Application.Services;

namespace LoanCalculation.Domain.Services
{
    public class ValidationService : IValidationService
    {
        public bool Validate(string[] args)
        {
            if (args.Length != 2)
            {
                return false;
            }

            if (!decimal.TryParse(args[0], out decimal input1) || !int.TryParse(args[1], out int input2))
            {
                return false;
            }

            if (input1 <= 0 || input2 <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
