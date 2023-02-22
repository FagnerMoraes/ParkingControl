using ParkingControl.Application.DTOs.Response;
using ParkingControl.Test.Base;

namespace ParkingControl.Domain.Test.Api.Fakes
{
    public class ParkingSpotResponseFake : IFake<ParkingSpotResponse>
    {
        private readonly Fixture _fixture;

        public ParkingSpotResponseFake(Fixture fixture)
        {
            _fixture = fixture;
        }

        public ParkingSpotResponse GerarEntidadeInvalida()
        {
            var response = _fixture.Build<ParkingSpotResponse>()
                .Without(x => x.LicensePlate)
                .Do(x => x.LicensePlate = string.Empty)
                .Create();

            return response;
        }

        public ParkingSpotResponse GerarEntidadeValida()
        {
            var response = _fixture.Build<ParkingSpotResponse>()
                .Without(x => x.LicensePlate)
                .Do(x => x.LicensePlate = "AAA1111")
                .Create();

            return response;
        }
    }
}