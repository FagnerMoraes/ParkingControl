using ParkingControl.Domain.Contexts.ParkingFees.Entities;

namespace ParkingControl.Domain.Contexts.ParkingFees.Repositories;
public interface IParkingFeeRepository
{
    Task<ParkingFee> GetByCarEntryTime(DateTime? date);
}
