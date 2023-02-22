using Microsoft.AspNetCore.Mvc;
using ParkingControl.Application.Contracts;
using ParkingControl.Application.DTOs.Request;
using ParkingControl.Application.DTOs.Response;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingSpotResponse>>> Get()
        {
            var parkeds = await _parkingSpotService.GetAllAsync();
            return Ok(parkeds);
        }

        [HttpPost("iniciar-estadia")]
        public async Task<ActionResult> Post(CreateParkingSpotRequest request)
        {

            if (ModelState.IsValid)
            {
                ParkingSpotResponse parkingSpot = await _parkingSpotService.CreateAsync(request);
                    return Created("",parkingSpot);
                //return CreatedAtAction(nameof(GetByLicensePlate), new { licensePlate = parkingSpot.LicensePlate }, parkingSpot.LicensePlate);
            }
            
            return BadRequest();
        }

        //[HttpGet("{licensePlate}")]
        //public async Task<ActionResult<ParkingSpotResponse>> GetByLicensePlate(string licensePlate)
        //{
        //    var result = await _parkingSpotService.GetByLicensePlateAsync(licensePlate);
        //    if(result is null)
        //        return NotFound();
        //    return Ok(result);
        //} 

        [HttpPut("{licensePlate}")]
        public async Task<ActionResult> Put(string licensePlate)
        {
            var ParkSpotResult = await _parkingSpotService.FinishParkingSpotByLicensePlateAsync(licensePlate);
            if(ParkSpotResult is null)
                return BadRequest();

            return NoContent();
        }

    }
}
