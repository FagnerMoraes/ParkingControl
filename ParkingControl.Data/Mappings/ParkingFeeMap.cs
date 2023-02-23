using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingControl.Domain.Entities;

namespace ParkingControl.Data.Mappings;
public class ParkingFeeMap : IEntityTypeConfiguration<ParkingFee>
{
    public void Configure(EntityTypeBuilder<ParkingFee> builder)
    {
        builder.ToTable("tb_taxa_estacionamento");

        builder.HasData(new[]
        {
            new ParkingFee(1,new DateTime(2023,01,01,00,00,01),new DateTime(2023,12,31,23,59,59),2.00m,1.00m)
        }); 
    }
}
