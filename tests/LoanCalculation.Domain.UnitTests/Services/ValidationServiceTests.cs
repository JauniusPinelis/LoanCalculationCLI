using FluentAssertions;
using LoanCalculation.Application.Services;
using LoanCalculation.Domain.Services;
using Xunit;

namespace LoanCalculation.Domain.UnitTests.Services
{
    public class ValidationServiceTests
    {
        private readonly IValidationService _validationService;

        public ValidationServiceTests()
        {
            _validationService = new ValidationService();
        }

        [Fact]
        public void Validate_GivenZeroParameters_ShouldNotValidate()
        {
            var args = new string[0];

            var validated = _validationService.Validate(args);

            validated.Should().BeFalse();
        }

        [Fact]
        public void Validate_GivenNonNumbers_ShouldNotValidate()
        {
            var args = new string[2] { "five", "six" };

            var validated = _validationService.Validate(args);

            validated.Should().BeFalse();
        }

        [Fact]
        public void Validate_GivenCorrectFormats_ShouldValidate()
        {
            var args = new string[2] { "50000", "10" };

            var validated = _validationService.Validate(args);

            validated.Should().BeTrue();
        }
    }
}
