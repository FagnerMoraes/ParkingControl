using ParkingControl.Application.DTOs.Request;
using ParkingControl.Application.DTOs.Response;
using ParkingControl.Domain.Entities;

namespace ParkingControl.Application.Contracts;
public interface IParkingSpotService : IDisposable 
{
    Task<IEnumerable<ParkingSpotResponse>> GetAllAsync();
    Task<int?> CreateAsync(CreateParkingSpotRequest request);
    Task<ParkingSpotResponse?> FinishParkingSpotByLicensePlateAsync(string licensePlate);
    Task<ParkingSpotResponse?> GetByLicensePlateAsync(string licensePlate);

}
