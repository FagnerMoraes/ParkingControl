using ParkingControl.Domain.Shared;

namespace ParkingControl.Domain.Calcs;
public class ParkingFeeCalculations : IParkingFeeCalculations
{
    public Decimal CalculationHourValue(int timeOfParkingInMinutes, Decimal fullHourPrice)
    {
        Decimal valueToPay = 0.00m;
        var resultOfDivision = timeOfParkingInMinutes / ParkingConstants.FULL_HOUR_IN_MINUTES;

        if (resultOfDivision >= 1)
            valueToPay += decimal.Multiply(fullHourPrice, resultOfDivision);

        return valueToPay;
    }

   public Decimal CalculationAditionalValue(int timeOfParkingInMinutes, Decimal fullHourPrice, Decimal aditionalHourPrice)
    {
        Decimal valueToPay = 0.00m;
        var remainderOfResultOfDivision = timeOfParkingInMinutes % ParkingConstants.FULL_HOUR_IN_MINUTES;

        if (remainderOfResultOfDivision > ParkingConstants.TOLERANCE_TIME_IN_MINUTES
                && remainderOfResultOfDivision <= ParkingConstants.HALF_HOUR_IN_MINUTES)
        {
            valueToPay += aditionalHourPrice;
        }
        else if (remainderOfResultOfDivision >= ParkingConstants.HALF_HOUR_IN_MINUTES)
        {
            valueToPay += fullHourPrice;
        }

        return valueToPay;
    }
}

