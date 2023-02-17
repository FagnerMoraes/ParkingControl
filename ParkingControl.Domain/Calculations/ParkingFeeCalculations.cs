using ParkingControl.Domain.Entities;
using ParkingControl.Domain.Shared;

namespace ParkingControl.Domain.Calcs;
public class ParkingFeeCalculations : IParkingFeeCalculations
{
    public Decimal CalculationHourValue(double timeOfParkinginMinutes, Decimal fullHourPrice)
    {
        Decimal ValueToPay = 0.00m;
        double ResultOfDivision = timeOfParkinginMinutes / ParkingConstants.FULL_HOUR_IN_MINUTES;

        if (ResultOfDivision > 0)
            ValueToPay += decimal.Multiply(fullHourPrice, (decimal)ResultOfDivision);

        return ValueToPay;
    }

   public Decimal CalculationAditionalValue(TimeSpan timeOfParking, Decimal fullHourPrice, Decimal aditionalHourPrice)
    {
        Decimal ValueToPay = 0.00m;
        var RemainderOfResultOfDivision = (int)timeOfParking.TotalMinutes % ParkingConstants.FULL_HOUR_IN_MINUTES;

        if (RemainderOfResultOfDivision >= ParkingConstants.TOLERANCE_TIME_IN_MINUTES
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

