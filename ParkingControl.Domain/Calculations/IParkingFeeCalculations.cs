using ParkingControl.Domain.Entities;
namespace ParkingControl.Domain.Calcs;
public interface IParkingFeeCalculations
{
    Decimal CalculationHourValue(double timeOfParking,Decimal FullHourPrice);
    Decimal CalculationAditionalValue(TimeSpan timeOfParking, Decimal FullHourPrice, Decimal AditionalHourPrice);
}
