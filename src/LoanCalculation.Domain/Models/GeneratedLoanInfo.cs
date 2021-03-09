using LoanCalculation.Domain.Extensions;
using LoanCalculation.Domain.Helpers;
using System.ComponentModel;
using System.Text;

namespace LoanCalculation.Domain.Models
{
    public class GeneratedLoanInfo
    {
        [DisplayName("Monthly Payment")]
        public decimal MonthlyPayment { get; set; }

        [DisplayName("Administration Fee")]
        public decimal AdministrationFee { get; set; }

        [DisplayName("Interest Total")]
        public decimal InterestTotal { get; set; }

        [DisplayName("Annual Percentage Rate")]
        public double AnnualPercentageRate { get; set; }

        /// <summary>
        /// Uses reflection to generate a table of <DisplayName, value> of all decimal Properties
        /// and merges it to string, separated each property by new line
        /// Also addiing
        /// </summary>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            var properties = this.GetType().GetProperties();
            foreach (var property in properties)
            {
                var displayName = ReflectionHelpers.GetDisplayName(property);

                if (property.PropertyType == typeof(decimal))
                {
                    var formattedValue = ReflectionHelpers.GetDecimal(property, this).ToCurrencyString();

                    stringBuilder.Append($"{displayName}: {formattedValue}\n");
                }
                if (property.PropertyType == typeof(double))
                {
                    var formattedValue = ReflectionHelpers.GetDecimal(property, this).ToString("#.000");

                    stringBuilder.Append($"{displayName}: {formattedValue}\n");
                }
            }

            return stringBuilder.ToString();
        }
    }
}
