using LoanCalculation.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LoanCalculation.Launcher
{

    class Program
    {

        static int Main(string[] args)
        {
            IServiceProvider serviceProvider = Service.InitServiceProvider();

            var CLI = serviceProvider.GetService<ICLI>();

            return CLI.Run(args);
        }
    }
}
