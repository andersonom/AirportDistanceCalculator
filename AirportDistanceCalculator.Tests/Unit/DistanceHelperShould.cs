using AirportDistanceCalculator.Helpers;
using Xunit;

namespace AirportDistanceCalculator.Tests.Unit
{
    public class DistanceHelperShould
    {
        [Theory]
        [InlineData(33.777196, -84.521143, 32.897462, -97.036128, 724.48271699471491)]
        public void ReturnCorrectDistanceInMiles(double lat1, double lon1, double lat2, double lon2, double expected)
        {
             //Arrange
            var miles = DistanceHelper.GetDistanceInMiles(lat1, lon1, lat2, lon2);
            Assert.Equal(miles, expected);
        }

        [Theory]
        [InlineData(32.777196, -84.521143, 32.897462, -97.036128, 724.48271699471491)]
        public void ReturnIncorrectDistanceInMiles(double lat1, double lon1, double lat2, double lon2, double expected)
        {
            //Arrange
            var miles = DistanceHelper.GetDistanceInMiles(lat1, lon1, lat2, lon2);
            Assert.NotEqual(miles, expected);
        }
    }
}
