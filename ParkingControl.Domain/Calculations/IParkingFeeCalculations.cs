using ParkingControl.Domain.Entities;
namespace ParkingControl.Domain.Calcs;
public interface IParkingFeeCalculations
{
    Decimal CalculationHourValue(ParkingSpot parkingSpot, ParkingFee parkingFee);
    Decimal CalculationAditionalValue(ParkingSpot parkingSpot, ParkingFee parkingFee);
}
