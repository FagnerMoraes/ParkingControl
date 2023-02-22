
using ParkingControl.Application.Contracts;
using ParkingControl.Test.Application.Fakes;

namespace ParkingControl.Test.Api.Controller
{
    public class ParkingSpotControllerTest
    {
        private readonly IParkingSpotService _parkingSpotService;
        private readonly Fixture _fixture;
        private readonly CreateParkingSpotRequestFake _createParkingSpotRequestTest;

        public ParkingSpotControllerTest()
        {
            _parkingSpotService = Substitute.For<IParkingSpotService>();
            _fixture = new Fixture();
            _createParkingSpotRequestTest = new CreateParkingSpotRequestFake(_fixture);
        }
    }
}
