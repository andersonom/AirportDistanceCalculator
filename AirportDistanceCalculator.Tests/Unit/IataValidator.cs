using AirportDistanceCalculator.Validators;
using FluentValidation.Results;
using Xunit;

namespace IataDistanceCalculator.Tests.Unit
{
    public class IataShould
    {
        private readonly IataValidator _validator;

        public IataShould()
        {
            //Arrange
            _validator = new IataValidator();
        }

        [Fact]
        public void BeValid()
        {
            //Act
            var sut = "AMS";

            ValidationResult results = _validator.Validate(sut);

            //Assert
            Assert.True(results.IsValid);
        }
        [Theory]
        [InlineData("")]
        [InlineData("AM")]
        [InlineData("A")]
        public void BeInvalid( string sut)
        {
            //Act sut
            ValidationResult results = _validator.Validate(sut);

            //Assert
            Assert.False(results.IsValid);
        }
    }

}