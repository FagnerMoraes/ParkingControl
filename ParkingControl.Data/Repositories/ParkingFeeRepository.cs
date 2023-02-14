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

    public async Task<ParkingFee?> GetByCarEntryTimeAsync(DateTime date)
    {
        var query = _context.parkingFees.FromSqlInterpolated($@"SELECT TOP 1 * from dbo.tb_taxa_estacionamento as t 
                                                                where  {date}
                                                                BETWEEN t.InitialValidityDate and t.FinalValidityDate");
        var result = await query.FirstOrDefaultAsync();
        return result;
    }
        
}
