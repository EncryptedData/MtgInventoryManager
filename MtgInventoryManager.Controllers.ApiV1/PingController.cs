using Microsoft.AspNetCore.Mvc;

namespace MtgInventoryManager.Controllers.ApiV1;

[ApiController]
[Route("/ping")]
public class PingController : ControllerBase
{
    [HttpGet]
    public IActionResult OnGet()
    {
        return Ok("pong");
    }
}