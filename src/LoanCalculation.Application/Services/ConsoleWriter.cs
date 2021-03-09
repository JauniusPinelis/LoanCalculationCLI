using LoanCalculation.Domain.Interfaces;
using System;

namespace LoanCalculation.Application.Services
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }
    }
}
