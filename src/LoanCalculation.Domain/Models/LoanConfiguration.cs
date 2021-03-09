namespace LoanCalculation.Domain.Models
{
    public class LoanConfiguration
    {
        public int DurationInMonths { get; set; }

        public int Amount { get; set; }

        public decimal MaxAdminFee { get; set; }

        public decimal PercentageAdminFee { get; set; }

        public decimal AnnualInterestRate { get; set; }
    }
}
