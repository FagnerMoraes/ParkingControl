using ParkingControl.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ParkingControl.Application.DTOs.Request
{
    public class CreateParkingSpotRequest
    {
        [Required(ErrorMessage ="Campo Obrigatorio")]
        [StringLength(8,ErrorMessage = "Campo {0} deve possuir entre {2} e {1} caracteres", MinimumLength = 7)]
        public string LicensePlate { get; set; } = string.Empty;

        public CreateParkingSpotRequest() { }

        public static implicit operator ParkingSpot(CreateParkingSpotRequest request)
        {
            var parkingSpot = new ParkingSpot(request.LicensePlate);
            return parkingSpot;
        }
    }
}
