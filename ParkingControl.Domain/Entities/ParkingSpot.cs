using ParkingControl.Domain.Enums;

namespace ParkingControl.Domain.Entities;
public class ParkingSpot
{
    public int Id { get; private set; }
    public string? LicensePlate { get; private set; }
    public DateTime CarEntryTime { get; private set; }
    public DateTime CarLeaveTime { get; private set; }
    public EParkingSpotStatus ParkingSpotStatus { get; private set; }
    public TimeSpan TimeOfParking { get; private set; }
    public Decimal PriceOfParking { get; private set; } = 0.00m;


    public ParkingSpot(string licensePlate)
    {
        LicensePlate = licensePlate;
        ParkingSpotStatus = EParkingSpotStatus.parked;
        CarEntryTime = DateTime.Now;
    }

    public void FinishParkingSpot()
    {
        ParkingSpotStatus = EParkingSpotStatus.finished;
        CarLeaveTime = DateTime.Now;
        TimeOfParking = CarLeaveTime - CarEntryTime;
    }

    public void AddPriceOfParking(decimal price) => PriceOfParking += price;




}
