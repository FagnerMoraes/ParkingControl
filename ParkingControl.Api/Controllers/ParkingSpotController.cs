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





        /// <summary>
        /// Obtem todas as vagas de estacionamento
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param>Metodo sem parametro</param>
        /// <returns></returns>
        /// <response code="200">Retorna a lista de vagas de estacionamento</response>
        /// <response code="404">Retorno caso não existam dados no banco</response>
        /// <response code="500">Retorna erros caso ocorram</response>
        [ProducesResponseType(typeof(ParkingSpotResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingSpotResponse>>> GetAllAsync()
        {
            var parkeds = await _parkingSpotService.GetAllAsync();

            if(parkeds is null)
                return NotFound();
            
            return Ok(parkeds);
        }

        /// <summary>
        /// Inserir uma nova vaga de estacionamento
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name= "request">dados do estacionamento</param>
        /// <returns></returns>
        /// <response code="201">Confirma o cadastro da vaga</response>
        /// <response code="400">Retorno caso não respeite o modelo de dados</response>
        /// <response code="500">Retorna erros caso ocorram</response>
        [ProducesResponseType(typeof(ParkingSpotResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("iniciar-estadia")]
        public async Task<ActionResult<ParkingSpotResponse>> Post(CreateParkingSpotRequest request)
        {

            if (ModelState.IsValid)
            {
                var parkingSpot = await _parkingSpotService.CreateAsync(request);
                
                    return Created("",parkingSpot);
                //return CreatedAtAction(nameof(GetByLicensePlate), new { licensePlate = parkingSpot.LicensePlate }, parkingSpot.LicensePlate);
            }
            
            return BadRequest();
        }

        /// <summary>
        /// Obtem uma vaga de estacionamento
        /// </summary>
        /// <remarks>
        /// Metodo para obter dados de uma vaga atraves da busca pela placa do veiculo
        /// </remarks>
        /// <param name= "licensePlate">Placa do veiculo para a busca</param>
        /// <returns></returns>
        /// <response code="200">Obter os dados da vaga</response>
        /// <response code="404">Retorno caso não seja encontrada vaga</response>
        /// <response code="500">Retorna erros caso ocorram</response>
        [ProducesResponseType(typeof(ParkingSpotResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]

        [HttpGet("{licensePlate}")]
        public async Task<ActionResult<ParkingSpotResponse>> GetByLicensePlate(string licensePlate)
        {
            var result = await _parkingSpotService.GetByLicensePlateAsync(licensePlate);
            
            if (result is null)
                return NotFound();

            return Ok(result);
        }


        /// <summary>
        /// Finaliza a estadia na vaga de estacionamento
        /// </summary>
        /// <remarks>
        /// Este metodo finaliza a estadia do veiculo
        /// </remarks>
        /// <param name= "licensePlate">Placa de veiculo para finalizar a estadia</param>
        /// <returns></returns>
        /// <response code="204">Confirma a finalização da estadia</response>
        /// <response code="400">Retorno caso ocorra algum problema ao finalizar a estadia</response>
        /// <response code="500">Retorna erros caso ocorram</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]

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
