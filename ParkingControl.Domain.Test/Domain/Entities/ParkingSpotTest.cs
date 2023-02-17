using ParkingControl.Domain.Entities;
using ParkingControl.Domain.Enums;

namespace ParkingControl.Test.Domain.Entities;
public class ParkingSpotTest
{
    [Fact]
    public void Deve_Gerar_Entidade_Com_Data_De_Entrada_E_Status_Estacionado()
    {
        // Arrange, act
        var newParkingSpot = new ParkingSpot("AAA1111");


        // Assert
        newParkingSpot.CarEntryTime.Should().NotBe(null);
        newParkingSpot.ParkingSpotStatus.Should().Be(EParkingSpotStatus.parked);

    }

    [Fact]
    public void Deve_Finalizar_Estadia_Com_Data_De_Saida_E_Status_Finalizado_Com_Valor_Da_Estadia()
    {
        // Arrange
        var newParkingSpot = new ParkingSpot("AAA1111");
        
        // Act
        newParkingSpot.FinishParkingSpot();

        // Assert
        newParkingSpot.CarLeaveTime.Should().NotBe(null);
        newParkingSpot.ParkingSpotStatus.Should().Be(EParkingSpotStatus.finished);
        newParkingSpot.TimeOfParking.Should().Be(newParkingSpot.CarLeaveTime - newParkingSpot.CarEntryTime);
    }

    [Fact]
    public void Deve_Acumular_Valor_A_Paga()
    {
        // Arrange
        var newParkingSpot = new ParkingSpot("AAA1111");
        Decimal valor = 5;
        Decimal segundoValor = 7;
        
        // Act
        newParkingSpot.AddPriceOfParking(valor);
        newParkingSpot.AddPriceOfParking(segundoValor);

        // Assert
        newParkingSpot.PriceOfParking.Should().Be(valor + segundoValor);
    }
}
