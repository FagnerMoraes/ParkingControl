using Microsoft.EntityFrameworkCore;
using ParkingControl.Data.DataContext;
using ParkingControl.Domain.Entities;
using ParkingControl.Domain.Repositories;

namespace ParkingControl.Data.Repositories;
public class ParkingSpotRepository : IParkingSpotRepository
{
    private readonly AppDbContext _context;

    public ParkingSpotRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ParkingSpot> CreateAsync(ParkingSpot parkingSpot)
    {
        await _context.parkingSpots.AddAsync(parkingSpot);
        await _context.SaveChangesAsync();
        return parkingSpot;
    }

    public async Task<IEnumerable<ParkingSpot>> GetAllAsync(){
        var result = await _context.parkingSpots.AsNoTracking().ToListAsync();
        return result.OrderByDescending(x => x.CarEntryTime);
    }  
              
    

    public async Task<ParkingSpot?> GetByLicensePlateAsync(string licensePlate)
    {
      var result =  await _context.parkingSpots
        .FirstOrDefaultAsync(x => x.LicensePlate == licensePlate);

        return result ?? null;
    }
       

    public async Task UpdateAsync(ParkingSpot parkingSpot)
    {
        _context.Entry(parkingSpot).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public void Dispose() =>
    _context.Dispose();

}
