using ParkingControl.Domain.Entities;

namespace ParkingControl.Domain.Repositories;
public interface IParkingSpotRepository
{
    Task<IEnumerable<ParkingSpot>> GetAllAsync();
    Task<ParkingSpot> CreateAsync(ParkingSpot parkingSpot);
    Task<ParkingSpot?> GetByLicensePlateAsync(string licensePlate);
    Task UpdateAsync(ParkingSpot parkingSpot);

}
