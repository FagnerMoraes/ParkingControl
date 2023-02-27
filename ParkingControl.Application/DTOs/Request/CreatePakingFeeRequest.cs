using ParkingControl.Domain.Entities;

namespace ParkingControl.Application.DTOs.Request;
public class CreatePakingFeeRequest
{
    public DateTime InitialValidityDate { get; set; }
    public DateTime FinalValidityDate { get; set; }
    public Decimal FullHourPrice { get; set; }
    public Decimal AditionalHourPrice { get; set; }

    public static implicit operator ParkingFee(CreatePakingFeeRequest request)
    {
        var parkingFee = new ParkingFee(
            request.InitialValidityDate,
            request.FinalValidityDate,
            request.FullHourPrice,
            request.AditionalHourPrice);
        
        return parkingFee;            
    }
}
