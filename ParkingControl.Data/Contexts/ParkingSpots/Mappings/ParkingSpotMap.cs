using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingControl.Domain.Contexts.PargingSpots.Entities;

namespace ParkingControl.Data.Contexts.ParkingSpots.Mappings;
public class ParkingSpotMap : IEntityTypeConfiguration<ParkingSpot>
{
    public void Configure(EntityTypeBuilder<ParkingSpot> builder)
    {
        builder.ToTable("tb_vaga_estacionamento");

        builder.Property(p => p.LicensePlate)
            .HasColumnName("col_placa_veiculo")
            .IsRequired();

        builder.Property(p => p.ParkingSpotStatus)
            .HasColumnName("col_status_vaga")
            .IsRequired();

        builder.Property(p => p.CarEntryTime)
            .HasColumnName("col_tempo_entrada_veiculo")
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(p => p.CarLeaveTime)
            .HasColumnName("col_tempo_saida_veiculo")
            .HasColumnType("datetime2");

        builder.Property(p => p.TimeOfParking)
            .HasColumnName("col_tempo_total_estacionamento")
            .HasColumnType("time");

        builder.Property(p => p.PriceOfParking)
            .HasColumnName("col_preco_estacionamento")
            .HasColumnType("time");
    }
}
