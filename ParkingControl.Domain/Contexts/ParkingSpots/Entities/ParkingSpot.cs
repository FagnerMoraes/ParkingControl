
namespace ParkingControl.Domain.Contexts.PargingSpots.Entities;
public class ParkingSpot
{
    public int Id { get; private set; }
    public string LicensePlate { get; private set; } = String.Empty;
    public DateTime CarEntryTime { get; private set; }
    public DateTime CarLeaveTime { get; private set; }
    public EParkingSpotStatus ParkingSpotStatus { get; private set; }
    public TimeSpan TimeOfParking { get; private set; }
    public decimal PriceOfParking { get; private set; }

    protected ParkingSpot() { }

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
    }

    public void CalcTimeOfParking()
    {
        TimeOfParking = CarLeaveTime - CarEntryTime;
    }




}
