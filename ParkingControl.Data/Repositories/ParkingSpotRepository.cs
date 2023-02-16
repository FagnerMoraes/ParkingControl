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

    

    public async Task<int?> CreateAsync(ParkingSpot parkingSpot)
    {
        await _context.parkingSpots.AddAsync(parkingSpot);
        await _context.SaveChangesAsync();
        return parkingSpot.Id;
    }



    public async Task<IEnumerable<ParkingSpot>> GetAllAsync()  =>
        await _context.parkingSpots.AsNoTracking().ToListAsync();       
    

    public async Task<ParkingSpot?> GetByLicensePlateAsync(string licensePlate)
        => await _context.parkingSpots
        .FirstOrDefaultAsync(x => x.LicensePlate.Contains(licensePlate));

    public async Task UpdateAsync(ParkingSpot parkingSpot)
    {
        _context.Entry(parkingSpot).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public void Dispose() =>
    _context.Dispose();

}
