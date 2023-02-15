using ParkingControl.Domain.Entities;

namespace ParkingControl.Domain.Repositories;
public interface IParkingSpotRepository : IDisposable
{
    Task<IEnumerable<ParkingSpot>> GetAllAsync();
    Task<int?> CreateAsync(ParkingSpot parkingSpot);
    Task<ParkingSpot?> GetByLicensePlateAsync(string licensePlate);
    Task UpdateAsync(ParkingSpot parkingSpot);

}
