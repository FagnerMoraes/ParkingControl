using ParkingControl.Domain.Entities;
using ParkingControl.Domain.Enums;

namespace ParkingControl.Application.DTOs.Response
{
    public class ParkingSpotResponse
    {
        public string LicensePlate { get; set; } = string.Empty;
        public string CarEntryDate { get; set; } = string.Empty;
        public string CarEntryTime { get; set; } = string.Empty;
        public string CarLeaveDate { get; set; } = string.Empty;
        public string CarLeaveTime { get; set; } = string.Empty;
        public string ParkingSpotStatus { get; set; } = string.Empty;
        public string TimeOfParking { get; set; } = string.Empty;
        public string PriceOfParking { get; set; } = string.Empty;

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
                PriceOfParking = parkingSpot.PriceOfParking.ToString(" 0.00")
            };
        }
    }
}

