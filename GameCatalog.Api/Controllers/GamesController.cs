using GameCatalog.Api.Data;
using GameCatalog.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameCatalog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController(AppDbContext db) : ControllerBase
{
    // GET: api/games
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Game>>> GetAll()
    => await db.Games.OrderBy(g => g.Title).ToListAsync();

    // GET: api/games/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Game>> Get(int id)
    => await db.Games.FindAsync(id) is { } game ? game : NotFound();

    // POST: api/games
    [HttpPost]
    public async Task<ActionResult<Game>> Create(Game game)
    {
        db.Games.Add(game);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = game.Id }, game);
    }

    // PUT: api/games/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Game game)
    {
        if (id != game.Id) return BadRequest();
        db.Entry(game).State = EntityState.Modified;
        await db.SaveChangesAsync();
        return NoContent();
    }


    // DELETE: api/games/5 (not in the UI atm)
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await db.Games.FindAsync(id);
        if (entity is null) return NotFound();
        db.Games.Remove(entity);
        await db.SaveChangesAsync();
        return NoContent();
    }
}