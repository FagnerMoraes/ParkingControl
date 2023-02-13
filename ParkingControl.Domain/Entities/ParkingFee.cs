namespace ParkingControl.Domain.Entities;
public class ParkingFee
{
    public ParkingFee(int id, DateTime initialValidityDate, DateTime finalValidityDate, Decimal fullHourPrice, Decimal aditionalHourPrice)
    {
        Id = id;
        InitialValidityDate = initialValidityDate;
        FinalValidityDate = finalValidityDate;
        FullHourPrice = fullHourPrice;
        AditionalHourPrice = aditionalHourPrice;
    }
    public ParkingFee(DateTime initialValidityDate, DateTime finalValidityDate, Decimal fullHourPrice, Decimal aditionalHourPrice) 
        : this(default, initialValidityDate, finalValidityDate, fullHourPrice, aditionalHourPrice) { }

    public int Id { get; set; }
    public DateTime InitialValidityDate { get; set; }
    public DateTime FinalValidityDate { get; set; }
    public Decimal FullHourPrice { get; set; }
    public Decimal AditionalHourPrice { get; set; }
}
