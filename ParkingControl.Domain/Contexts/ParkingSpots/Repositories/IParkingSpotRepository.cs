using ParkingControl.Domain.Contexts.PargingSpots.Entities;

namespace ParkingControl.Domain.Contexts.PargingSpots.Repositories;
public interface IParkingSpotRepository
{
    Task<int?> CreateAsync(ParkingSpot parkingSpot);
    Task<ParkingSpot?> GetByLicensePlateAsync(string licensePlate);
    Task UpdateAsync(ParkingSpot parkingSpot);
}
