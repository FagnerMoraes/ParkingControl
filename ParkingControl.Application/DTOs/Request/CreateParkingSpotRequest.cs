using ParkingControl.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ParkingControl.Application.DTOs.Request
{
    public class CreateParkingSpotRequest
    {
        public string LicensePlate { get; set; } = string.Empty;

        public CreateParkingSpotRequest() { }

        public static implicit operator ParkingSpot(CreateParkingSpotRequest request)
        {
            var parkingSpot = new ParkingSpot(request.LicensePlate);
            return parkingSpot;
        }
    }
}
