using Microsoft.EntityFrameworkCore;
using ParkingControl.Data.DataContext;
using ParkingControl.Domain;
using ParkingControl.Domain.Contexts.PargingSpots.Entities;
using ParkingControl.Domain.Contexts.PargingSpots.Repositories;

namespace ParkingControl.Data.Contexts.ParkingSpots.Repositories;
public class ParkingSpotRepository : IParkingSpotRepository
{
    private readonly AppDbContext _context;

    public ParkingSpotRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int?> CreateAsync(ParkingSpot parkingSpot)
    {
        await _context.parkingSpots.AddAsync(parkingSpot);
        await _context.SaveChangesAsync();
        return parkingSpot.Id;
    }

    public async Task<ParkingSpot?> GetParkingSpotByLicensePlateAsync(string licensePlate)
    {
        var parkingSpot = await _context.parkingSpots
                                    .FirstOrDefaultAsync(x => x.ParkingSpotStatus != EParkingSpotStatus.finished);
        if (parkingSpot is null)
            return null;

        return parkingSpot;
    }

    public Task UpdateAsync(ParkingSpot parkingSpot)
    {
        throw new NotImplementedException();
    }
}
