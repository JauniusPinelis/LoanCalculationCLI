using FluentAssertions;
using LoanCalculation.Tests.Common;
using Xunit;

namespace LoanCalculation.Application.IntegrationTests
{
    public class CLITests : CLITestBase
    {
        [Fact]
        public void Run_GivenCorrentParameters_CLIReturnsZero()
        {
            var input = new string[] { "50000", "10" };

            var response = Cli.Run(input);

            response.Should().Be(0);
        }

        [Fact]
        public void Run_GivenIncorrectParameters_CLIReturnsOne()
        {
            var input = new string[] { "50000", "" };

            var response = Cli.Run(input);

            response.Should().Be(1);
        }
    }
}
