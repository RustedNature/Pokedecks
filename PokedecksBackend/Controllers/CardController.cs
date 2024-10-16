using Microsoft.AspNetCore.Mvc;
using PokedecksBackend.Data;

namespace PokedecksBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CardController(DataContext context) : ControllerBase
{
    [HttpGet]
    public IActionResult GetCards()
    {
        var cards = context.Cards.ToList();
        return Ok(cards);
    }
}