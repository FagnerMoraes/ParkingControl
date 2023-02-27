using Microsoft.AspNetCore.Mvc;
using ParkingControl.Application.Contracts;
using ParkingControl.Application.DTOs.Request;
using ParkingControl.Application.DTOs.Response;

namespace ParkingControl.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParkingFeeController : ControllerBase
{
    private readonly IParkingFeeService _parkingFeeService;

    public ParkingFeeController(IParkingFeeService parkingFeeService)
    {
        _parkingFeeService = parkingFeeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ParkingFeeResponse>>> GetAllAsync()
    {
        var parkingFeesResponse = await _parkingFeeService.GetAllAsync();

        if (parkingFeesResponse is null)
            return NotFound();

        return Ok(parkingFeesResponse);
    }

    [HttpPost]
    public async Task<ActionResult<ParkingFeeResponse>> Post(CreatePakingFeeRequest createPakingFeeRequest)
    {
        if (ModelState.IsValid)
        {
            var parkingFeeResponse = await _parkingFeeService.createAsync(createPakingFeeRequest);

            return Created("", parkingFeeResponse);
        }

        return BadRequest();
    }

    [HttpPut]
    public async Task<ActionResult<ParkingFeeResponse>> Put(UpdateParkingFeeRequest updateParkingFeeRequest)
    {
        if (ModelState.IsValid)
        {
            var response = await _parkingFeeService.updateAsync(updateParkingFeeRequest);
            if (response is null)
                return BadRequest();

            return Ok(response);
        }

        return BadRequest();
    }
}