using ParkingControl.Domain.Calcs;

namespace ParkingControl.Test.Domain.Calculations
{
    public class ParkingFeeCalculationsTest
    {

        [Theory]
        [InlineData(10, 2.0, 1.0, 0.00)]
        [InlineData(25, 2.0, 1.0, 1.00)]
        [InlineData(30, 2.0, 1.0, 1.00)]
        [InlineData(60, 2.0, 1.0, 2.00)]
        [InlineData(70, 2.0, 1.0, 2.00)]        
        [InlineData(75, 2.0, 1.0, 3.00)]
        [InlineData(125, 2.0, 1.0, 4.00)]
        [InlineData(135, 2.0, 1.0, 5.00)]
        public void Deve_Retornar_O_Valor_Da_Estadia(
            int timeOfParkingInMinutes, Decimal FullHourPrice,
            Decimal HalfHourPrice, decimal resultExpected)
        {
            //Arrange
            var calc = new ParkingFeeCalculations();
            decimal result = 0.0m;
            // Act
            result += calc.CalculationHourValue(timeOfParkingInMinutes, FullHourPrice);
            result += calc.CalculationAditionalValue(timeOfParkingInMinutes, FullHourPrice, HalfHourPrice);


            // Assert
            result.Should().Be(resultExpected);
        }
    }
}
