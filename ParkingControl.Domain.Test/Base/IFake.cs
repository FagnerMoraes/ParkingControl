using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingControl.Test.Base
{
    public interface IFake<T>
    {
        T GerarEntidadeValida();
        T GerarEntidadeInvalida();
    }
}
