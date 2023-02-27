using ParkingControl.Domain.Entities;

namespace ParkingControl.Domain.Repositories;
public interface IParkingFeeRepository
{
    Task<IEnumerable<ParkingFee>> GetAllAsync();
    Task<ParkingFee> CreateAsync(ParkingFee parkingFee);
    Task<ParkingFee> UpdateAsync(ParkingFee parkingFee);

    Task<ParkingFee?> GetByCarEntryTimeAsync(DateTime date);


}
