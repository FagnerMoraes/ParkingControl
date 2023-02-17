using ParkingControl.Domain.Calcs;

namespace ParkingControl.Test.Domain.Calculations
{
    public class ParkingFeeCalculationsTest
    {
        private readonly IParkingFeeCalculations _parkingFeeCalculations;

        public ParkingFeeCalculationsTest()
        {
            // Arrange
            _parkingFeeCalculations = Substitute.For<IParkingFeeCalculations>();
        }
        [Theory]
        [InlineData(120, 2.0,4.00)]
        public void Deve_Retornar(double timeOfParking, Decimal FullHourPrice, decimal result)
        {
            //Arrange

            // Act
           var value = _parkingFeeCalculations.
                        CalculationHourValue(timeOfParking,FullHourPrice).Returns(result);


            // Assert
            value.Should().Be(result);

        }
    }
}
