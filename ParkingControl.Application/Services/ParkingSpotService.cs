using ParkingControl.Application.Contracts;
using ParkingControl.Application.DTOs.Request;
using ParkingControl.Domain.Calcs;
using ParkingControl.Domain.Entities;
using ParkingControl.Domain.Repositories;

namespace ParkingControl.Application.Services;
public class ParkingSpotService : IParkingSpotService
{
    private readonly IParkingSpotRepository _parkingSpotRepository;
    private readonly IParkingFeeRepository _parkingFeeRepository;

    public ParkingSpotService(IParkingSpotRepository parkingSpotRepository, IParkingFeeRepository parkingFeeRepository)
    {
        _parkingSpotRepository = parkingSpotRepository;
        _parkingFeeRepository = parkingFeeRepository;
    }

    public async Task<int?> CreateAsync(CreateParkingSpotRequest request)
    {
        ParkingSpot newParkingSpot = request;
        var id = (int)await _parkingSpotRepository.CreateAsync(newParkingSpot);
        if (id == 0)
            return null;

        return id;
    }

    public async Task<ParkingSpot?> FinishParkingSpotByLicensePlateAsync(string licensePlate)
    {
        var parkingSpotResult = await GetByLicensePlateAsync(licensePlate);
        if (parkingSpotResult is null)
            return null;

        parkingSpotResult.FinishParkingSpot();
        parkingSpotResult.CalcTimeOfParking();        

        var parkingFeeResult = await _parkingFeeRepository.GetByCarEntryTime(parkingSpotResult.CarEntryTime);
        if (parkingFeeResult is null)
            return null;

        var priceResult = ParkingFeeCalcs.CalcValueFee(parkingSpotResult, parkingFeeResult);

        parkingSpotResult.AddPriceOfParking(priceResult);

        _parkingSpotRepository.Update(parkingSpotResult);

        return parkingSpotResult;
    }

    public async Task<ParkingSpot?> GetByLicensePlateAsync(string licensePlate)
    {
        var parkingSpotResult = await _parkingSpotRepository.GetByLicensePlateAsync(licensePlate);
        if (parkingSpotResult is null)
            return null;

        return parkingSpotResult;
    }
}
