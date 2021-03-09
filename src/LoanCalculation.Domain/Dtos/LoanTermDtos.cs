using LoanCalculation.Domain.Models;

namespace LoanCalculation.Domain.Dtos
{
    public class LoanTermDtos
    {
        public decimal AnnualInterestRate { get; set; }

        public AdministrationFee AdministrationFee { get; set; }
    }
}
