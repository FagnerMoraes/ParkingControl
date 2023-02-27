using ParkingControl.Application.Contracts;
using ParkingControl.Application.DTOs.Request;
using ParkingControl.Application.DTOs.Response;
using ParkingControl.Domain.Entities;
using ParkingControl.Domain.Repositories;

namespace ParkingControl.Application.Services;
public class ParkingFeeService : IParkingFeeService
{
    private readonly IParkingFeeRepository _parkingFeeRepository;

    public ParkingFeeService(IParkingFeeRepository parkingFeeRepository) =>
        _parkingFeeRepository = parkingFeeRepository;

    public async Task<IEnumerable<ParkingFeeResponse>> GetAllAsync()
    {
        var parkingFees = await _parkingFeeRepository.GetAllAsync();

        var parkingFeeReponse = new List<ParkingFeeResponse>();

        foreach(var parkingFee in parkingFees)
        {
            parkingFeeReponse.Add(parkingFee);
        }

        return parkingFeeReponse;

    }

    public async Task<ParkingFeeResponse> createAsync(CreatePakingFeeRequest createParkingFee)
    {
        ParkingFee parkingFee = createParkingFee;
        var parkingFeeResponse = await _parkingFeeRepository.CreateAsync(parkingFee);

        return parkingFeeResponse;

    }

    public async Task<ParkingFeeResponse> updateAsync(UpdateParkingFeeRequest updateParkingFee)
    {
        ParkingFee parkingFee = updateParkingFee;

        var parkinFeeResponse = await _parkingFeeRepository.UpdateAsync(parkingFee);

        return parkinFeeResponse;

    }
}
