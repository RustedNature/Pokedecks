using Microsoft.AspNetCore.Mvc;
using PokedecksBackend.Data;
using PokedecksBackend.Models.DTOs.Series;
using PokedecksBackend.Models.Entities;

namespace PokedecksBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeriesController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;

    [HttpGet]
    public IActionResult GetSeries()
    {
        if (!ModelState.IsValid) return BadRequest();
        var series = _context.Series.ToList();

        return Ok(series);
    }

    [HttpPost]
    public async Task<IActionResult> AddSeries([FromBody] AddSeriesDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest();
        if (_context.Series.Any(x => x.Id == dto.Id)) return Conflict();

        var series = new Series(dto);

        await _context.Series.AddAsync(series);
        await _context.SaveChangesAsync();

        return Created();
    }


    [HttpPut("{id}")]
    public IActionResult EditSeries(string id, [FromBody] EditSeriesDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest();
        var series = _context.Series.Find(id);

        if (series == null) return NotFound($"No series with id: {id} found");

        series.LogoNetworkUri = dto.LogoNetworkUri ?? series.LogoNetworkUri;

        _context.SaveChanges();


        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteSeries(string id)
    {
        if (!ModelState.IsValid) return BadRequest();
        var series = _context.Series.Find(id);

        if (series == null) return NotFound();
        _context.Series.Remove(series);
        _context.SaveChanges();
        return NoContent();
    }
}