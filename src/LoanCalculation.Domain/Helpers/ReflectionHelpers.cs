using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace LoanCalculation.Domain.Helpers
{
    public static class ReflectionHelpers
    {
        public static string GetDisplayName(PropertyInfo propertyInfo)
        {
            var attribute = propertyInfo.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().FirstOrDefault();

            return attribute?.DisplayName ?? "Missing DisplayName";
        }

        public static decimal GetDecimal(PropertyInfo propertyInfo, object obj)
        {
            return Decimal.Parse(propertyInfo.GetValue(obj, null).ToString());
        }
    }
}
