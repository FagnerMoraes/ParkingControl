
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingControl.Api.Controllers;
using ParkingControl.Application.Contracts;
using ParkingControl.Domain.Test.Api.Fakes;
using ParkingControl.Test.Application.Fakes;

namespace ParkingControl.Test.Api.Controller
{
    public class ParkingSpotControllerTest
    {
        private readonly IParkingSpotService _parkingSpotService;
        private readonly Fixture _fixture;
        private readonly CreateParkingSpotRequestFake _createParkingSpotRequestTest;
        private readonly ParkingSpotResponseFake _parkingSpotResponse;
        private readonly ParkingSpotController _parkingControl;

        public ParkingSpotControllerTest()
        {
            _parkingSpotService = Substitute.For<IParkingSpotService>();
            _fixture = new Fixture();
            _createParkingSpotRequestTest = new CreateParkingSpotRequestFake(_fixture);
            _parkingSpotResponse = new ParkingSpotResponseFake(_fixture);

            _parkingControl = new ParkingSpotController(_parkingSpotService);
        }

        [Fact]
        public async Task Ao_Criar_Vaga_Deve_Retornar_O_StatusCodes_Status201Created()
        {
            // Arrange
            var createRequestFake = _createParkingSpotRequestTest.GerarEntidadeValida();
            var createResponseFake = _parkingSpotResponse.GerarEntidadeValida();
            var statusCodeExpected = StatusCodes.Status201Created;
            _parkingSpotService.CreateAsync(createRequestFake).Returns(createResponseFake);
            // Act
            var createResponse = await _parkingControl.Post(createRequestFake);

            // Assert
            createResponse.Should().BeOfType<CreatedResult>()
            .Which.StatusCode.Should().Be(statusCodeExpected);

            _parkingControl.ModelState.IsValid.Should().BeTrue();

        }

        [Fact]
        public async Task Ao_Criar_Vaga_Deve_Retornar_O_StatusCodes_Status400BadRequest()
        {
            // Arrange
            var createRequestFake = _createParkingSpotRequestTest.GerarEntidadeInvalida();            
            _parkingControl.ModelState.AddModelError("LicensePlate", "A placa do veículo é obrigatória.");
            var texto = "A placa do veículo é obrigatória.";
            var statusCodeExpected = StatusCodes.Status400BadRequest;

            // Act
            var createResponse = await _parkingControl.Post(createRequestFake);

            // Assert
            createResponse.Should().BeOfType<BadRequestResult>()
            .Which.StatusCode.Should().Be(statusCodeExpected);

            _parkingControl.ModelState.IsValid.Should().BeFalse();

        }



    }
}
