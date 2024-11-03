using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokedecksBackend.Data;

namespace PokedecksBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CardController(DataContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCards()
    {
        var cards = await context.Cards.ToListAsync();
        return Ok(cards);
    }
}