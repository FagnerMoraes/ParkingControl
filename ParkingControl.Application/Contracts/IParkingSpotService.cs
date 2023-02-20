using ParkingControl.Application.DTOs.Request;
using ParkingControl.Application.DTOs.Response;
using ParkingControl.Domain.Entities;

namespace ParkingControl.Application.Contracts;
public interface IParkingSpotService : IDisposable 
{
    Task<IEnumerable<ParkingSpotResponse>> GetAllAsync();
    Task<ParkingSpotResponse> CreateAsync(CreateParkingSpotRequest parkingSpot);
    Task<ParkingSpotResponse?> FinishParkingSpotByLicensePlateAsync(string licensePlate);
    Task<ParkingSpotResponse?> GetByLicensePlateAsync(string licensePlate);

}
