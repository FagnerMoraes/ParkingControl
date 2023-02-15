using Microsoft.AspNetCore.Mvc;
using ParkingControl.Application.Contracts;
using ParkingControl.Application.DTOs.Request;
using ParkingControl.Application.DTOs.Response;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingSpotResponse>>> Get()
        {
            var parkeds = await _parkingSpotService.GetAllAsync();
            return Ok(parkeds);
        }

        [HttpPost("iniciar-estadia")]
        public async Task<ActionResult<int>> Post(CreateParkingSpotRequest request)
        {
            
            var id = await _parkingSpotService.CreateAsync(request);
            if (id is null)
                return BadRequest();
            return Created("",id);
        }

        [HttpGet("obter-por-placa")]
        public async Task<ActionResult<ParkingSpotResponse>> GetByLicensePlate(string licensePlate)
        {
            var result = await _parkingSpotService.GetByLicensePlateAsync(licensePlate);
            if(result is null)
                return NotFound();
            return Ok(result);
        } 

        [HttpPut("finalizar-estadia")]
        public async Task<ActionResult<ParkingSpotResponse>> Put(string licensePlate)
        {
            var ParkSpotResult = await _parkingSpotService.FinishParkingSpotByLicensePlateAsync(licensePlate);
            if(ParkSpotResult is null)
                return BadRequest();
            return Ok();
        }
    }
}
