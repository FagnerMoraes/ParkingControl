using Microsoft.EntityFrameworkCore;
using ParkingControl.Data.DataContext;
using ParkingControl.Domain.Entities;
using ParkingControl.Domain.Enums;
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
       var query = from fees in _context.parkingFees
                    select fees;

        var result = await query.FirstOrDefaultAsync();

            
            //await _context.parkingFees.Join(x => x.)
            //.FirstOrDefaultAsync(x => x.InitialValidityDate >= date && x.FinalValidityDate <= date);
        return result;
    }
        
}
