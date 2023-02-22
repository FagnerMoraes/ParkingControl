
namespace ParkingControl.Test.Base
{
    public interface IFake<T>
    {
        T GerarEntidadeValida();

        T GerarEntidadeInvalida();
    }
}
