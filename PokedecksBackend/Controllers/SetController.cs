using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokedecksBackend.Data;
using PokedecksBackend.Models.DTOs.Set;
using PokedecksBackend.Models.Entities;

namespace PokedecksBackend.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class SetController(DataContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetSets()
    {
        if (!ModelState.IsValid) return BadRequest();
        var sets = await context.Sets.ToListAsync();

        return Ok(sets);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSet(string id)
    {
        if (!ModelState.IsValid) return BadRequest();
        var set = await context.Sets.FindAsync(id);
        if (set is null) return NotFound($"Set with id: {id} not found");
        return Ok(set);
    }

    [HttpPost]
    public async Task<IActionResult> AddSet([FromBody] AddSetDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest();
        if (await context.Sets.AnyAsync(s => s.Id == dto.Id)) return Conflict($"The set {dto.Id} already exists");

        var series = await context.Series.FindAsync(dto.SeriesId);
        if (series == null) return NotFound($"No series found with ID: {dto.SeriesId}");

        var set = new Set(dto, series);

        series.Sets.Add(set);

        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSet), new { id = set.Id }, set);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditSeries(string id, [FromBody] EditSetDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest();
        var set = await context.Sets.FindAsync(id);
        if (set is null) return NotFound($"Set with id: {id} not found");

        set.Name = dto.Name ?? set.Name;
        set.Logo = dto.Logo ?? set.Logo;
        set.Symbol = dto.Symbol ?? set.Symbol;
        set.CardCountTotal = dto.CardCountTotal ?? set.CardCountTotal;
        set.CardCountPrintedTotal = dto.CardCountPrintedTotal ?? set.CardCountPrintedTotal;

        await context.SaveChangesAsync();

        return Ok(set);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSet(string id)
    {
        if (!ModelState.IsValid) return BadRequest();
        var set = await context.Sets.FindAsync(id);
        if (set is null) return NotFound($"Set with id: {id} not found");
        
        context.Sets.Remove(set);
        
        await context.SaveChangesAsync();
        
        return Ok(set);
    }
}