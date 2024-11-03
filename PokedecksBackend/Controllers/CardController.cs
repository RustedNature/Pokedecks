using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokedecksBackend.Data;
using PokedecksBackend.Models.DTOs.Card;
using PokedecksBackend.Models.Entities;

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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCard(string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var card = await context.Cards.FindAsync(id);
        if (card is null) return NotFound("Card not found");

        return Ok(card);
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> AddCard(string id, [FromBody] AddCardDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (await context.Cards.AnyAsync(c => c.Id == dto.Id)) return NotFound($"Card {dto.Id} not found");

        var set = await context.Sets.FindAsync(id);
        if (set is null) return NotFound($"Set {dto.SetId} not found");

        Card card = new(dto, set);

        set.Cards.Add(card);

        await context.SaveChangesAsync();
        return Ok(card);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditCard(string id, [FromBody] EditCardDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var card = await context.Cards.FindAsync(id);
        if (card is null) return NotFound($"Card {id} not found");

        card.Name = dto.Name ?? card.Name;
        card.ImageLowRes = dto.ImageLowRes ?? card.ImageLowRes;
        card.ImageHighRes = dto.ImageHighRes ?? card.ImageHighRes;

        await context.SaveChangesAsync();

        return Ok(card);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCard(string id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var card = await context.Cards.FindAsync(id);
        if (card is null) return NotFound($"Card {id} not found");

        context.Cards.Remove(card);

        await context.SaveChangesAsync();

        return NoContent();
    }
}