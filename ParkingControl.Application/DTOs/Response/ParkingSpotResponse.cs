using ParkingControl.Domain.Entities;
using ParkingControl.Domain.Enums;

namespace ParkingControl.Application.DTOs.Response
{
    public class ParkingSpotResponse
    {
        public string LicensePlate { get; set; } = string.Empty;
        public string CarEntryTime { get; set; } = string.Empty;
        public string CarLeaveTime { get; set; } = string.Empty;
        public string ParkingSpotStatus { get; set; } = string.Empty;
        public string? TimeOfParking { get; set; }
        public Decimal PriceOfParking { get; set; } = 0.00m;

        public ParkingSpotResponse()
        {

        }

        public static implicit operator ParkingSpotResponse(ParkingSpot parkingSpot)
        {
            return new ParkingSpotResponse
            {
                LicensePlate = parkingSpot.LicensePlate,
                CarEntryTime = parkingSpot.CarEntryTime.ToShortTimeString(),
                CarLeaveTime = parkingSpot.CarLeaveTime.ToShortTimeString(),
                ParkingSpotStatus = parkingSpot.ParkingSpotStatus.ToString(),
                TimeOfParking = parkingSpot.TimeOfParking.ToString(@"hh\:mm\:ss"),
                PriceOfParking = parkingSpot.PriceOfParking
            };
        }
    }
}

