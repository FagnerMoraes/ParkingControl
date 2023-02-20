using ParkingControl.Domain.Entities;

namespace ParkingControl.Domain.Repositories;
public interface IParkingSpotRepository : IDisposable
{
    Task<IEnumerable<ParkingSpot>> GetAllAsync();
    Task<object> CreateAsync(ParkingSpot parkingSpot);
    Task<ParkingSpot?> GetByLicensePlateAsync(string licensePlate);
    Task UpdateAsync(ParkingSpot parkingSpot);

}
