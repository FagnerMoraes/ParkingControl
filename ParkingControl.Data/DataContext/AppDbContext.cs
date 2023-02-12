using Microsoft.EntityFrameworkCore;
using ParkingControl.Domain.Contexts.PargingSpots.Entities;
using System.Reflection;

namespace ParkingControl.Data.DataContext;
public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options) : base(options){ }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

	public DbSet<ParkingSpot> parkingSpots { get; set; } = null!;
}
