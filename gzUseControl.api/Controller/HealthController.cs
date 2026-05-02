using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gzUseControl.api.Controller;

// health controller - контроллер для проверки работы сервера
[Route("api/[controller]")]
[ApiController]
public class HealthController : ControllerBase
{
    // get health - проверка что сервер работает
    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok(new
        {
            status = "ok",
            message = "GearZone backend rabotaet"
        });
    }
}