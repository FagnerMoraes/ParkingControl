using ParkingControl.Domain.Shared;

namespace ParkingControl.Domain.Calcs;
public class ParkingFeeCalculations : IParkingFeeCalculations
{
    public Decimal CalculationHourValue(int timeOfParkingInMinutes, Decimal fullHourPrice)
    {
        Decimal ValueToPay = 0.00m;
        var ResultOfDivision = timeOfParkingInMinutes / ParkingConstants.FULL_HOUR_IN_MINUTES;

        if (ResultOfDivision >= 1)
            ValueToPay += decimal.Multiply(fullHourPrice, ResultOfDivision);

        return ValueToPay;
    }

   public Decimal CalculationAditionalValue(int timeOfParkingInMinutes, Decimal fullHourPrice, Decimal aditionalHourPrice)
    {
        Decimal ValueToPay = 0.00m;
        var RemainderOfResultOfDivision = timeOfParkingInMinutes % ParkingConstants.FULL_HOUR_IN_MINUTES;

        if (RemainderOfResultOfDivision > ParkingConstants.TOLERANCE_TIME_IN_MINUTES
                && RemainderOfResultOfDivision <= ParkingConstants.HALF_HOUR_IN_MINUTES)
        {
            ValueToPay += aditionalHourPrice;
        }
        else if (RemainderOfResultOfDivision >= ParkingConstants.HALF_HOUR_IN_MINUTES)
        {
            ValueToPay += fullHourPrice;
        }

        return ValueToPay;
    }
}

