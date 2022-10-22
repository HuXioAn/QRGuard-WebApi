using Microsoft.AspNetCore.Mvc;
using QRGuard;

namespace QRGuard_RESTful.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QRGuardController : ControllerBase
{


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

    [HttpGet("{id}/code")]
    public IActionResult GetCode(string id)
    {
        var guard = new Guard();
        string? codePath = guard.GuardGen(id);
        //Console.WriteLine(codePath);

        Byte[] code = System.IO.File.ReadAllBytes(codePath);

        return File(code,"image/jpeg");
    }


}