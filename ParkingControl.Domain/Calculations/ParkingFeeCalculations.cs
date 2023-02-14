using ParkingControl.Domain.Entities;
using ParkingControl.Domain.Shared;

namespace ParkingControl.Domain.Calcs;
public class ParkingFeeCalculations : IParkingFeeCalculations
{
    public Decimal CalculationHourValue(ParkingSpot parkingSpot, ParkingFee parkingFee)
    {
        Decimal ValorAPagar = 0.00m;

        int ResultOfDivision = (int)parkingSpot.TimeOfParking.TotalMinutes / ParkingConstants.FULL_HOUR_IN_MINUTES;

        if (ResultOfDivision > 0)
            ValorAPagar += decimal.Multiply(parkingFee.FullHourPrice, (decimal)ResultOfDivision);

        return ValorAPagar;
    }

   public Decimal CalculationAditionalValue(ParkingSpot parkingSpot, ParkingFee parkingFee)
    {
        Decimal Valor = 0.00m;
        var RemainderOfResultOfDivision = (int)parkingSpot.TimeOfParking.TotalMinutes % ParkingConstants.FULL_HOUR_IN_MINUTES;

        if (RemainderOfResultOfDivision >= ParkingConstants.TOLERANCE_TIME_IN_MINUTES
                && RemainderOfResultOfDivision <= ParkingConstants.HALF_HOUR_IN_MINUTES)
        {
            Valor += parkingFee.FullHourPrice / ParkingConstants.NUMBER_TO_GET_HALF_VALUE;
        }
        else if (RemainderOfResultOfDivision >= ParkingConstants.HALF_HOUR_IN_MINUTES)
        {
            Valor += parkingFee.FullHourPrice;
        }

        return Valor;
    }
}

