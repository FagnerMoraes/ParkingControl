using Microsoft.EntityFrameworkCore;
using ParkingControl.Data.DataContext;
using ParkingControl.Domain.Contexts.ParkingFees.Entities;
using ParkingControl.Domain.Contexts.ParkingFees.Repositories;

namespace ParkingControl.Data.Contexts.ParkingFees.Repositories;
public class ParkingFeeRepository : IParkingFeeRepository
{
    private readonly AppDbContext _context;

    public ParkingFeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ParkingFee> GetByCarEntryTime(DateTime? date)
    {
        var parkingfee = await _context.parkingFees
                        .FirstOrDefaultAsync(x => x.InitialVaidityDate >= date && x.FinalVaidityDate <= date);

        if (parkingfee is null)
            return null;

        return parkingfee;
    }
}
