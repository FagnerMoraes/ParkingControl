using Microsoft.AspNetCore.Mvc;
using ParkingControl.Application.Contracts;
using ParkingControl.Application.DTOs.Request;
using ParkingControl.Domain.Entities;

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

        [HttpPost("iniciar-estadia")]
        public async Task<ActionResult<int>> Post(CreateParkingSpotRequest request)
        {
            
            var id = await _parkingSpotService.CreateAsync(request);
            if (id is null)
                return BadRequest();
            return Ok(id);
        }

        [HttpGet("obter-por-placa")]
        public async Task<ActionResult<ParkingSpot>> Get(string licensePlate)
        {
            var result = await _parkingSpotService.GetByLicensePlateAsync(licensePlate);
            return Ok(result);
        } 

        [HttpPut("finalizar-estadia")]
        public async Task<ActionResult<ParkingSpot>> Put(string licensePlate)
        {
            var ParkSpotResult = await _parkingSpotService.FinishParkingSpotByLicensePlateAsync(licensePlate);
            return Ok();
        }
    }
}
