using Microsoft.AspNetCore.Mvc;
using ParkingControl.Application.Contracts;
using ParkingControl.Application.DTOs.Request;
using ParkingControl.Application.DTOs.Response;
using ParkingControl.Domain.Calcs;
using ParkingControl.Domain.Entities;
using ParkingControl.Domain.Repositories;

namespace ParkingControl.Application.Services;
public class ParkingSpotService : IParkingSpotService
{
    private readonly IParkingSpotRepository _parkingSpotRepository;
    private readonly IParkingFeeRepository _parkingFeeRepository;
    private readonly IParkingFeeCalculations _parkingFeeCalculations;



    public ParkingSpotService(IParkingSpotRepository parkingSpotRepository,
                              IParkingFeeRepository parkingFeeRepository,
                              IParkingFeeCalculations parkingFeeCalculations)
    {
        _parkingSpotRepository = parkingSpotRepository;
        _parkingFeeRepository = parkingFeeRepository;
        _parkingFeeCalculations = parkingFeeCalculations;
    }

    public async Task<IEnumerable<ParkingSpotResponse>> GetAllParkedAsync()
    {
        var parkingSpots = await _parkingSpotRepository.GetAllParkedAsync();

        List<ParkingSpotResponse> ListOfParkingSpot = new List<ParkingSpotResponse>();

        foreach (var parkingSpot in parkingSpots)
        {
            ListOfParkingSpot.Add(parkingSpot);
        }

        return ListOfParkingSpot;

    }

    public async Task<int?> CreateAsync(CreateParkingSpotRequest request)
    {
        ParkingSpot newParkingSpot = request;
        var id = (int)await _parkingSpotRepository.CreateAsync(newParkingSpot);
        if (id == 0)
            return null;

        return id;
    }

    public async Task<ParkingSpotResponse> FinishParkingSpotByLicensePlateAsync(string licensePlate)
    {
        var parkingSpotResult = await GetByLicensePlateAsync(licensePlate);
        if (parkingSpotResult is null)
            return null;

        parkingSpotResult.FinishParkingSpot();       

        var parkingFeeResult = await _parkingFeeRepository.GetByCarEntryTimeAsync(parkingSpotResult.CarEntryTime);
        if (parkingFeeResult is null)
            return null;

        var priceResult = _parkingFeeCalculations.CalculationHourValue(parkingSpotResult, parkingFeeResult);
        parkingSpotResult.AddPriceOfParking(priceResult);
        var priceAditional = _parkingFeeCalculations.CalculationAditionalValue(parkingSpotResult, parkingFeeResult);
        parkingSpotResult.AddPriceOfParking(priceAditional);

        await _parkingSpotRepository.UpdateAsync(parkingSpotResult);

        return parkingSpotResult;
    }

    

    public async Task<ParkingSpot?> GetByLicensePlateAsync(string licensePlate)
    {
        var parkingSpotResult = await _parkingSpotRepository.GetByLicensePlateAsync(licensePlate);
        if (parkingSpotResult is null)
            return null;

        return parkingSpotResult;
    }

    public void Dispose() =>
        _parkingSpotRepository.Dispose();
}
