
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using ParkingControl.Api.Controllers;
using ParkingControl.Application.Contracts;
using ParkingControl.Application.DTOs.Response;
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
            _parkingSpotService.CreateAsync(createRequestFake).Returns(createResponseFake);
            // Act
            var createResponse = await _parkingControl.Post(createRequestFake);

            // Assert
            createResponse.Should().BeOfType<CreatedResult>();

            _parkingControl.ModelState.IsValid.Should().BeTrue();

        }

        [Fact]
        public async Task Ao_Tentar_Criar_Vaga_Com_Campo_Vazio_Deve_Retornar_O_StatusCodes_Status400BadRequest()
        {
            // Arrange
            var createRequestFake = _createParkingSpotRequestTest.GerarEntidadeInvalida();            
            _parkingControl.ModelState.AddModelError("LicensePlate", "A placa do veículo é obrigatória.");
           
            // Act
            var createResponse = await _parkingControl.Post(createRequestFake);

            // Assert
            createResponse.Should().BeOfType<BadRequestResult>();

            _parkingControl.ModelState.IsValid.Should().BeFalse();

        }

        [Fact]
        public async Task Ao_Finalizar_Vaga_Deve_Retornar_StatusCodes_Status204NoContent()
        {
            // Arrange
            var licensePlate = "AAA1111";
            var createResponseFake = _parkingSpotResponse.GerarEntidadeValida();
           // var statusCodeExpected = StatusCodes.Status204NoContent;
            _parkingSpotService.FinishParkingSpotByLicensePlateAsync(licensePlate).Returns(createResponseFake);
           
            // Act
            var response = await _parkingControl.Put(licensePlate);

            // Assert
            response.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task Ao_Tentar_Finalizar_Vaga_Deve_Retornar_StatusCodes_Status400BadRequest()
        {
            // Arrange
            var licensePlate = "AAA1111";
            ParkingSpotResponse parkingSpotResponse = null;
            _parkingSpotService.FinishParkingSpotByLicensePlateAsync(licensePlate).Returns(parkingSpotResponse);
           
            // Act
            var response = await _parkingControl.Put(licensePlate);

            // Assert
            response.Should().BeOfType<BadRequestResult>();
        }
    }
}
