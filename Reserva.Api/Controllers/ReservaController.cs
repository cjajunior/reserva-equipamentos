using Microsoft.AspNetCore.Mvc;
using Reserva.Domain.Entities;
using Reserva.Infrastructure;

namespace Reserva.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservaController : ControllerBase
{
    private readonly ReservaService _reservaService;

    public ReservaController(ReservaService reservaService)
    {
        _reservaService = reservaService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ReservaEntity reserva)
    {
        await _reservaService.AdicionarAsync(reserva);
        return Ok(reserva);
    }
}
