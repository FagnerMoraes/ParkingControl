using ParkingControl.Application.DTOs.Request;
using ParkingControl.Test.Base;

namespace ParkingControl.Test.Application.Fakes;
public class CreateParkingSpotRequestTest : IFake<CreateParkingSpotRequest>
{
    private readonly Fixture _fixture;

    public CreateParkingSpotRequestTest(Fixture fixture)
    {
        _fixture = fixture;
    }

    public CreateParkingSpotRequest GerarEntidadeInvalida()
    {
        var request = _fixture.Build<CreateParkingSpotRequest>()
            .Without(x => x.LicensePlate)
            .Do(x => x.LicensePlate = string.Empty)
            .Create();

        return request;
    }

    public CreateParkingSpotRequest GerarEntidadeValida()
    {
        var request = _fixture.Build<CreateParkingSpotRequest>()
            .Without(x => x.LicensePlate)
            .Do(x => x.LicensePlate = "AAA1111")
            .Create();

        return request;
    }
}
