using Microsoft.EntityFrameworkCore;
using ParkingControl.Data.DataContext;
using ParkingControl.Domain.Entities;
using ParkingControl.Domain.Repositories;

namespace ParkingControl.Data.Repositories;
public class ParkingFeeRepository : IParkingFeeRepository
{
    private readonly AppDbContext _context;

    public ParkingFeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ParkingFee?> GetByCarEntryTime(DateTime? date)
    {
       var result = await _context.parkingFees
            .FirstOrDefaultAsync(x => x.InitialValidityDate >= date && x.FinalValidityDate <= date);
        return result;
    }
        
}
