using Microsoft.AspNetCore.Mvc;
using GameCatalogApi.Models;
using GameCatalogApi.Services;

namespace GameCatalogApi.Controllers
{
    [ApiController]
    [Route("api/Games/{gameId}/reviews")]
    public class ReviewsController : ControllerBase
    {
        private readonly GameService _gameService;

        public ReviewsController(GameService gameService)
        {
            _gameService = gameService;
        }

        // GET: api/Games/5/reviews
        [HttpGet]
        public ActionResult<IEnumerable<Review>> GetByGame(int gameId)
        {
            if (_gameService.GetGame(gameId) == null)
                return NotFound($"Game with ID {gameId} not found");

            return Ok(_gameService.GetReviewsByGameId(gameId));
        }

        // GET: api/Reviews/5
        [HttpGet("/api/Reviews/{id}")]
        public ActionResult<Review> GetById(int id)
        {
            var review = _gameService.GetReview(id);

            if (review == null)
                return NotFound($"Review with ID {id} not found");

            return review;
        }

        // POST: api/Games/5/reviews
        [HttpPost]
        public ActionResult<Review> Create(int gameId, Review review)
        {
            if (_gameService.GetGame(gameId) == null)
                return NotFound($"Game with ID {gameId} not found");

            review.GameId = gameId;
            var newReview = _gameService.CreateReview(review);

            return CreatedAtAction(nameof(GetById), new { id = newReview.Id }, newReview);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("/api/Reviews/{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _gameService.DeleteReview(id);

            if (!deleted)
                return NotFound($"Review with ID {id} not found");

            return NoContent();
        }
    }
}
