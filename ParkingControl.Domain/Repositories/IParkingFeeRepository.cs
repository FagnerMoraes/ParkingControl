using ParkingControl.Domain.Entities;

namespace ParkingControl.Domain.Repositories;
public interface IParkingFeeRepository
{
    Task<ParkingFee?> GetByCarEntryTime(DateTime? date);
}
