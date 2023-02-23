using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ParkingControl.Api.Controllers
{


    [ApiExplorerSettings(IgnoreApi =true)]
    public class ThrowController : ControllerBase
    {
        [Route("/error")]
        public IActionResult HandlerError() =>
            Problem();

        [Route("error-development")]
        public IActionResult HandlerErrorDevelopment(
            [FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }
            var exeptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return Problem(
                detail: exeptionHandlerFeature.Error.StackTrace,
                title: exeptionHandlerFeature.Error.Message);
        }
    }
}
