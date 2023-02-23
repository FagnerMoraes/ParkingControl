using ParkingControl.Domain.Entities;
using ParkingControl.Domain.Enums;

namespace ParkingControl.Application.DTOs.Response
{
    public class ParkingSpotResponse
    {
        public string? LicensePlate { get; set; }
        public string? CarEntryDate { get; set; }
        public string? CarEntryTime { get; set; } 
        public string? CarLeaveDate { get; set; } 
        public string? CarLeaveTime { get; set; } 
        public string? ParkingSpotStatus { get; set; } 
        public string? TimeOfParking { get; set; } 
        public decimal? PriceOfParking { get; set; }

        public ParkingSpotResponse()
        {

        }

        public static implicit operator ParkingSpotResponse(ParkingSpot parkingSpot)
        {
            return new ParkingSpotResponse
            {
                LicensePlate = parkingSpot.LicensePlate,
                CarEntryDate = parkingSpot.CarEntryTime.ToShortDateString(),
                CarEntryTime = parkingSpot.CarEntryTime.ToShortTimeString(),
                CarLeaveDate = parkingSpot.CarLeaveTime.ToShortDateString(),
                CarLeaveTime = parkingSpot.CarLeaveTime.ToShortTimeString(),
                ParkingSpotStatus = parkingSpot.ParkingSpotStatus.ToString(),
                TimeOfParking = parkingSpot.TimeOfParking.ToString(@"hh\:mm\:ss"),
                PriceOfParking = parkingSpot.PriceOfParking
            };
        }
    }
}

