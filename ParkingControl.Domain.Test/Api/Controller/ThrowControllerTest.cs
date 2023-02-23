using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using ParkingControl.Api.Controllers;

namespace ParkingControl.Test.Api.Controller;
public class ThrowControllerTest
{
    private readonly ThrowController _throwController;
    private readonly IHostEnvironment _hostEnvironment;
    private readonly IExceptionHandlerFeature _exceptionHandlerFeature;
    private readonly DefaultHttpContext _defaultHttpContext;

    public ThrowControllerTest()
    {
        _hostEnvironment = Substitute.For<IHostEnvironment>();
        _throwController = new ThrowController();
        _exceptionHandlerFeature = Substitute.For<IExceptionHandlerFeature>();
        _defaultHttpContext = new DefaultHttpContext();
    }

    [Fact]
    public void HandlerError_Returns_Problem()
    {
        var result = _throwController.HandlerError();

        result.Should().NotBeNull().And.BeOfType<ObjectResult>();
        var objectResult = result as ObjectResult;
        objectResult.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
    }

}
