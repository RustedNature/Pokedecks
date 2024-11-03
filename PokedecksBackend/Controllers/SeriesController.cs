using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokedecksBackend.Data;
using PokedecksBackend.Models.DTOs.Series;
using PokedecksBackend.Models.Entities;

namespace PokedecksBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeriesController(DataContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetSeries()
    {
        if (!ModelState.IsValid) return BadRequest();
        var series = await context.Series.ToListAsync();

        return Ok(series);
    }

    [HttpPost]
    public async Task<IActionResult> AddSeries([FromBody] AddSeriesDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest();
        if (await context.Series.AnyAsync(x => x.Id == dto.Id)) return Conflict();

        var series = new Series(dto);

        await context.Series.AddAsync(series);
        await context.SaveChangesAsync();

        return Created();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> EditSeries(string id, [FromBody] EditSeriesDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest();

        var series = await context.Series.FindAsync(id);
        if (series == null) return NotFound($"No series with id: {id} found");

        series.LogoNetworkUri = dto.LogoNetworkUri ?? series.LogoNetworkUri;

        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSeries(string id)
    {
        if (!ModelState.IsValid) return BadRequest();
        var series = await context.Series.FindAsync(id);

        if (series == null) return NotFound();
        context.Series.Remove(series);
        await context.SaveChangesAsync();
        return NoContent();
    }
}