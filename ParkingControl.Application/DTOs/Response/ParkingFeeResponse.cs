using ParkingControl.Domain.Entities;

namespace ParkingControl.Application.DTOs.Response;
public class ParkingFeeResponse
{
    public int Id { get; set; }
    public string InitialValidityDate { get; set; }
    public string FinalValidityDate { get; set; }
    public Decimal FullHourPrice { get; set; }
    public Decimal AditionalHourPrice { get; set; }


    public static implicit operator ParkingFeeResponse(ParkingFee parkingFee)
    {
        return new ParkingFeeResponse
        {
            Id = parkingFee.Id,
            InitialValidityDate = parkingFee.InitialValidityDate.ToShortDateString(),
            FinalValidityDate = parkingFee.FinalValidityDate.ToShortDateString(),
            FullHourPrice = parkingFee.FullHourPrice,
            AditionalHourPrice = parkingFee.AditionalHourPrice

        };
    }
}
