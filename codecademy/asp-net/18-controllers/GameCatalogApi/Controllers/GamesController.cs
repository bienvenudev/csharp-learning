using Microsoft.AspNetCore.Mvc;
using GameCatalogApi.Models;
using GameCatalogApi.Services;

namespace GameCatalogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly GameService _gameService;

        public GamesController(GameService gameService)
        {
            _gameService = gameService;
        }

        // GET: api/Games
        [HttpGet]
        public ActionResult<IEnumerable<Game>> GetAll() => Ok(_gameService.GetAllGames());

        // GET: api/Games/5
        [HttpGet("{id}")]
        public ActionResult<Game> GetById(int id)
        {
            var game = _gameService.GetGame(id);

            if (game == null)
                return NotFound($"Game with ID {id} not found");

            return game;
        }

        // GET: api/Games/search?title=skyrim&genre=rpg&releaseYear=2011
        [HttpGet("search")]
        public ActionResult<IEnumerable<Game>> Search(
            [FromQuery] string? title,
            [FromQuery] string? genre,
            [FromQuery] int? releaseYear)
        {
            return Ok(_gameService.SearchGames(title, genre, releaseYear));
        }

        // POST: api/Games
        [HttpPost]
        public ActionResult<Game> Create(Game game)
        {
            var newGame = _gameService.CreateGame(game);

            return CreatedAtAction(nameof(GetById), new { id = newGame.Id }, newGame);
        }

        // PUT: api/Games/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Game game)
        {
            if (id != game.Id)
                return BadRequest("ID mismatch between URL and game object");

            var updated = _gameService.UpdateGame(id, game);

            if (!updated) return NotFound($"Game with ID {id} not found.");

            return NoContent();
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _gameService.DeleteGame(id);

            if (!deleted)
                return NotFound($"Game with ID {id} not found");

            return NoContent();
        }
    }
}
