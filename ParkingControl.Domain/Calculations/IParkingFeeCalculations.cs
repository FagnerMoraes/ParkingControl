using ParkingControl.Domain.Entities;
namespace ParkingControl.Domain.Calcs;
public interface IParkingFeeCalculations
{
    Decimal CalculationHourValue(int timeOfParkingInMinutes, Decimal FullHourPrice);
    Decimal CalculationAditionalValue(int timeOfParkingInMinutes, Decimal FullHourPrice, Decimal AditionalHourPrice);
}
