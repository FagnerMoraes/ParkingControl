using Microsoft.AspNetCore.Mvc;
using ParkingControl.Application.Contexts.ParkingSpots.Contracts;
using ParkingControl.Application.Contexts.ParkingSpots.DTOs.Request;

namespace ParkingControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingSpotController : ControllerBase
    {
        private readonly IParkingSpotService _parkingSpotService;

        public ParkingSpotController(IParkingSpotService parkingSpotService)
        {
            _parkingSpotService = parkingSpotService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CreateParkingSpotRequest request)
        {
            var id = await _parkingSpotService.CreateAsync(request);
            if (id is null)
                return BadRequest();
            return Ok(id);
        }
    }
}
