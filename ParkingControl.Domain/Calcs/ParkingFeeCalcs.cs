﻿using ParkingControl.Domain.Entities;
using ParkingControl.Domain.Shared;

namespace ParkingControl.Domain.Calcs;
public static class ParkingFeeCalcs
{
    public static decimal CalcValueFee(ParkingSpot parkingSpot, ParkingFee parkingFee)
    {
        decimal ValorAPagar = 0.00m;

        int ResultOfDivision = (int)parkingSpot.TimeOfParking.TotalMinutes / ParkingConstants.FULL_HOUR_IN_MINUTES;
        var RemainderOfResultOfDivision = (int)parkingSpot.TimeOfParking.TotalMinutes % ParkingConstants.FULL_HOUR_IN_MINUTES;


        if (ResultOfDivision > 0)
        {
            ValorAPagar += decimal.Multiply(parkingFee.FullHourPrice, (decimal)ResultOfDivision);
            CalcAditionalValue();

        }
        else
        {
            CalcAditionalValue();
        }

        void CalcAditionalValue()
        {
            if (RemainderOfResultOfDivision >= ParkingConstants.TOLERANCE_TIME_IN_MINUTES
                    && RemainderOfResultOfDivision <= ParkingConstants.HALF_HOUR_IN_MINUTES)
            {
                ValorAPagar += parkingFee.FullHourPrice / ParkingConstants.NUMBER_TO_GET_HALF_VALUE;
            }
            else if(RemainderOfResultOfDivision >= ParkingConstants.HALF_HOUR_IN_MINUTES)
            {
                ValorAPagar += parkingFee.FullHourPrice;
            }
        }

        return ValorAPagar;

    }
}

