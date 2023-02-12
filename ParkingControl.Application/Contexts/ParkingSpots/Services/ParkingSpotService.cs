using ParkingControl.Application.Contexts.ParkingSpots.Contracts;
using ParkingControl.Application.Contexts.ParkingSpots.DTOs.Request;
using ParkingControl.Domain.Contexts.PargingSpots.Entities;
using ParkingControl.Domain.Contexts.PargingSpots.Repositories;

namespace ParkingControl.Application.Contexts.ParkingSpots.Services;
public class ParkingSpotService : IParkingSpotService
{
    private readonly IParkingSpotRepository _parkingSpotRepository;

    public ParkingSpotService(IParkingSpotRepository parkingSpotRepository)
    {
        _parkingSpotRepository = parkingSpotRepository;
    }

    public async Task<int?> CreateAsync(CreateParkingSpotRequest request)
    {
        ParkingSpot newParkingSpot = request;
        var id = (int)await _parkingSpotRepository.CreateAsync(newParkingSpot);
        if (id == 0)
            return null;

        return id;
    }
}
