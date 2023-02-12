using ParkingControl.Domain.Contexts.PargingSpots.Entities;
using System.ComponentModel.DataAnnotations;

namespace ParkingControl.Application.Contexts.ParkingSpots.DTOs.Request
{
    public class CreateParkingSpotRequest
    {
        [Required]
        public string LicensePlate { get; set; } = String.Empty;

        public CreateParkingSpotRequest() { }

        public static implicit operator ParkingSpot(CreateParkingSpotRequest request)
        {
            var parkingSpot = new ParkingSpot(request.LicensePlate);
            return parkingSpot;           
        }
    }
}
