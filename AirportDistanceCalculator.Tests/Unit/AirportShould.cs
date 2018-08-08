using AirportDistanceCalculator.Models;
using AirportDistanceCalculator.Tests.Fixture;
using AirportDistanceCalculator.Validators;
using FluentValidation.Results;
using Xunit;

namespace AirportDistanceCalculator.Tests.Unit
{
    public class AirportShould
    {
        private readonly AirportValidator _validator;
        public AirportShould()
        {
            //Arrange
            _validator = new AirportValidator();
        }

        [Fact]
        public void BeValid()
        {
            //Act
            Airport sut = AirportFixture.GetValidAirport;

            ValidationResult results = _validator.Validate(sut);

            //Assert
            Assert.True(results.IsValid);
        }
    }
}
