using Microsoft.AspNetCore.Mvc;
using PokedecksBackend.Data;

namespace PokedecksBackend.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class SetController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;

    [HttpGet]
    public IActionResult GetSets()
    {
        if (!ModelState.IsValid) return BadRequest();
        var sets = _context.Sets.ToList();

        return Ok(sets);
    }
}