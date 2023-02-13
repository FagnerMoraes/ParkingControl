using ParkingControl.Application.DTOs.Request;
using ParkingControl.Domain.Entities;

namespace ParkingControl.Application.Contracts;
public interface IParkingSpotService
{
    Task<int?> CreateAsync(CreateParkingSpotRequest request);
    Task<ParkingSpot?> FinishParkingSpotByLicensePlateAsync(string licensePlate);
    Task<ParkingSpot?> GetByLicensePlateAsync(string licensePlate);

}
