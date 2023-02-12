namespace ParkingControl.Domain.Contexts.ParkingFees.Entities;
public class ParkingFee
{
    public int Id { get; set; }
    public DateTime InitialVaidityDate { get; set; }
    public DateTime FinalVaidityDate { get; set; }
    public decimal InitialHourValue { get; set; }
    public TimeOnly ToleranceTime { get; set; }
    public decimal AditionalTimeValue { get; set; }
}
