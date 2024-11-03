using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokedecksBackend.Data;

namespace PokedecksBackend.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class SetController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetSets()
    {
        if (!ModelState.IsValid) return BadRequest();
        var sets = await _context.Sets.ToListAsync();

        return Ok(sets);
    }
}