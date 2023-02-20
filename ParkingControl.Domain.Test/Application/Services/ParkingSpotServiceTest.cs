using ParkingControl.Application.Contracts;
using ParkingControl.Application.Services;
using ParkingControl.Domain.Calcs;
using ParkingControl.Domain.Entities;
using ParkingControl.Domain.Repositories;
using ParkingControl.Test.Application.Fakes;

namespace ParkingControl.Test.Application.Services;
public class ParkingSpotServiceTest
{

    private readonly IParkingSpotRepository _parkingSpotRepository;
    private readonly IParkingFeeRepository _parkingFeeRepository;
    private readonly IParkingFeeCalculations _parkingFeeCalculations;
    private readonly ParkingSpotService _parkingSpotService;
    private readonly ParkingFee _parkingFee;
    private readonly Fixture _fixture;
    private readonly CreateParkingSpotRequestTest _createParkingSpotRequestTest;



    public ParkingSpotServiceTest()
    {
        _parkingSpotRepository = Substitute.For<IParkingSpotRepository>();
        _parkingFeeRepository = Substitute.For<IParkingFeeRepository>();
        _parkingFeeCalculations = Substitute.For<IParkingFeeCalculations>();
        _parkingSpotService = new ParkingSpotService(_parkingSpotRepository, _parkingFeeRepository, _parkingFeeCalculations);

        _parkingFee = new ParkingFee(1, new DateTime(2023, 01, 01, 00, 00, 01), new DateTime(2023, 12, 31, 23, 59, 59), 2.00m, 1.00m);
        _fixture = new Fixture();
        _createParkingSpotRequestTest = new CreateParkingSpotRequestTest(_fixture);
    }

    [Fact]
    public async Task Deve_Obter_Todos_Os_Registros()
    {
        //Arrange
        var createRequest = _createParkingSpotRequestTest.GerarEntidadeValida();
        ParkingSpot parkingSpot = createRequest;
        _parkingSpotRepository.GetAllAsync().Returns(new List<ParkingSpot>
        {
            parkingSpot,
            parkingSpot,
            parkingSpot
        });

        //Act
        var parkingSpots = await _parkingSpotService.GetAllAsync();

        //Assert
        parkingSpots.Should().NotBeEmpty().And.HaveCount(3);
    }

    [Fact]
    public async Task Deve_Retornar_Null_Ao_Tentar_Criar_Entidade()
    {
        //Arrange
        var createRequest = _createParkingSpotRequestTest.GerarEntidadeValida();
        ParkingSpot parkingSpot = createRequest;
        object? licensePlate = null;
        _parkingSpotRepository.CreateAsync(parkingSpot).Returns(licensePlate);

        //Act
        var ParkingSpotID = await _parkingSpotService.CreateAsync(createRequest);

        //Assert
        ParkingSpotID.Should().BeNull();
    }

    [Fact]
    public async Task Deve_Retornar_Placa_Veiculo_Ao_Criar_Entidade()
    {
        //Arrange
        var createRequest = _createParkingSpotRequestTest.GerarEntidadeValida();
        ParkingSpot parkingSpot = new ParkingSpot("AAA1111");
        string licensePlate = "AAA1111";
        _parkingSpotRepository.CreateAsync(parkingSpot).Returns(parkingSpot);
      
        //Act
        var ParkingSpot = await _parkingSpotService.CreateAsync(createRequest);

        //Assert
        ParkingSpot.LicensePlate.Should().Be(licensePlate);
    }

    [Fact]
    public async Task Ao_Finalizar_Estadia_Com_Entidade_Nula_Deve_Retornar_Null()
    {
        //Arrange
        ParkingSpot parkingSpot = null;
        string licensePlate = "AAA1111";
        _parkingSpotRepository.GetByLicensePlateAsync(licensePlate).Returns(parkingSpot);

        //Act
        var parkingSpotResult = await _parkingSpotService.FinishParkingSpotByLicensePlateAsync(licensePlate);

        //Assert
        parkingSpotResult.Should().BeNull();

    }

    [Fact]
    public async Task Ao_Finalizar_Estadia_Com_ParkingSpot_Ja_Finalizado_Deve_Retornar_Null()
    {
        //Arrange
        string licensePlate = "AAA1111";
        ParkingSpot parkingSpot = new ParkingSpot(licensePlate);
        parkingSpot.FinishParkingSpot();
        _parkingSpotRepository.GetByLicensePlateAsync(licensePlate).Returns(parkingSpot);

        //Act
        var parkingSpotResult = await _parkingSpotService.FinishParkingSpotByLicensePlateAsync(licensePlate);

        //Assert
        parkingSpotResult.Should().BeNull();

    }

    [Fact]
    public async Task Ao_Finalizar_Estadia_Com_ParkingFee_Nula_Deve_Retornar_Null()
    {
        //Arrange
        string licensePlate = "AAA1111";
        ParkingSpot parkingSpot = new ParkingSpot(licensePlate);
        
        _parkingSpotRepository.GetByLicensePlateAsync(licensePlate).Returns(parkingSpot);

        ParkingFee parkingFee = null;

        _parkingFeeRepository.GetByCarEntryTimeAsync(parkingSpot.CarEntryTime).Returns(parkingFee);

        //Act
        var parkingSpotResult = await _parkingSpotService.FinishParkingSpotByLicensePlateAsync(licensePlate);

        //Assert
        parkingSpotResult.Should().BeNull();

    }

    [Fact]
    public async Task Ao_Finalizar_Estadia_Deve_Retornar_Entidade_Com_Valor()
    {
        //Arrange
        string licensePlate = "AAA1111";
        ParkingSpot parkingSpot = new ParkingSpot(licensePlate);

        _parkingSpotRepository.GetByLicensePlateAsync(licensePlate).Returns(parkingSpot);

        _parkingFeeRepository.GetByCarEntryTimeAsync(parkingSpot.CarEntryTime).Returns(_parkingFee);
        _parkingFeeCalculations
            .CalculationHourValue((int)parkingSpot.TimeOfParking.TotalMinutes,
            _parkingFee.FullHourPrice).Returns(2.00m);
        _parkingFeeCalculations
            .CalculationAditionalValue((int)parkingSpot.TimeOfParking.TotalMinutes,
            _parkingFee.FullHourPrice,_parkingFee.AditionalHourPrice).Returns(1.00m);


        //Act
        var parkingSpotResult = await _parkingSpotService.FinishParkingSpotByLicensePlateAsync(licensePlate);

        //Assert
        parkingSpotResult.PriceOfParking.Should().Be("3,00");

    }



}
