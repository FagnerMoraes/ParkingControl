using ParkingControl.Domain.Entities;
using ParkingControl.Test.Base;

namespace ParkingControl.Test.Application.Fakes;
public class ParkingSpotFake : IFake<ParkingSpot>
{
    private readonly Fixture _fixture;

    public ParkingSpot GerarEntidadeInvalida()
    {
        throw new NotImplementedException();
    }

    public ParkingSpot GerarEntidadeValida()
    {
        throw new NotImplementedException();
    }
}
