using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingControl.Application.DTOs.Request
{
    public class UpdateParkingSpotRequest
    {
        public string LicensePlate { get; set; } = string.Empty;
    }
}
