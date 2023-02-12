using ParkingControl.Application.Contexts.ParkingSpots.DTOs.Request;
using ParkingControl.Domain.Contexts.PargingSpots.Entities;

namespace ParkingControl.Application.Contexts.ParkingSpots.Contracts;
public interface IParkingSpotService
{
    Task<int?> CreateAsync(CreateParkingSpotRequest request);
    Task<ParkingSpot> GetParkingSpotByLicensePlateAsync(string licensePlate);
    Task PutPriceOfParkingAsync(DateTime date);

    //Task<ParkingSpot?> GetByDateAsync(string licensePlate);
}
