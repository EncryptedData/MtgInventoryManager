using Microsoft.AspNetCore.Mvc;
using MtgInventoryManager.Models.Persistence;

namespace MtgInventoryManager.Controllers.ApiV1;

[ApiController]
[Route("/ping")]
public class PingController : ControllerBase
{
    [HttpGet]
    public IActionResult OnGet()
    {
        var card = new Card(); 
        return Ok(card);
    }
}