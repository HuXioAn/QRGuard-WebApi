using Microsoft.AspNetCore.Mvc;
using QRGuard;

namespace QRGuard_RESTful.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QRGuardController : ControllerBase
{


    private readonly ILogger<WeatherForecastController> _logger;

    public QRGuardController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id}")]
    public QRGuard Get(string id)
    {
        var guard = new Guard();
        
        return new QRGuard{
            name = id,
            reqTime = DateTime.Now,
            qrCodePath = guard.GuardGen(id)
        };
    }
}