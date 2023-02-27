using ParkingControl.Application.DTOs.Request;
using ParkingControl.Application.DTOs.Response;

namespace ParkingControl.Application.Contracts;
public interface IParkingFeeService
{
    Task<ParkingFeeResponse> createAsync(CreatePakingFeeRequest parkingFee);
    Task<IEnumerable<ParkingFeeResponse>> GetAllAsync();
    Task<ParkingFeeResponse> updateAsync(UpdateParkingFeeRequest updateParkingFeeRequest);

}
