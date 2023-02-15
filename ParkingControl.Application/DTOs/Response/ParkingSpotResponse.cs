using ParkingControl.Domain.Entities;
using ParkingControl.Domain.Enums;

namespace ParkingControl.Application.DTOs.Response
{
    public class ParkingSpotResponse
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public DateTime CarEntryTime { get; set; }
        public DateTime CarLeaveTime { get; set; }
        public string ParkingSpotStatus { get; set; } = string.Empty;
        public TimeSpan? TimeOfParking { get; set; }
        public Decimal PriceOfParking { get; set; } = 0.00m;

        public ParkingSpotResponse()
        {

        }

        public static implicit operator ParkingSpotResponse(ParkingSpot parkingSpot)
        {
            return new ParkingSpotResponse
            {
                Id = parkingSpot.Id,
                LicensePlate = parkingSpot.LicensePlate,
                CarEntryTime = parkingSpot.CarEntryTime,
                CarLeaveTime = parkingSpot.CarLeaveTime,
                ParkingSpotStatus = parkingSpot.ParkingSpotStatus.ToString(),
                TimeOfParking = parkingSpot.TimeOfParking,
                PriceOfParking = parkingSpot.PriceOfParking
            };
        }
    }
}

