using goods_server.Contracts;
using goods_server.Service.InterfaceService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goods_server.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        // GET: api/Rating/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRatingById(int id)
        {
            var rating = await _ratingService.GetRatingByIdAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            return Ok(rating);
        }

        // GET: api/Rating/product/5
        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetRatingsByProductId(int productId)
        {
            var ratings = await _ratingService.GetRatingsByProductIdAsync(productId);
            return Ok(ratings);
        }

        // POST: api/Rating
        [HttpPost]
        public async Task<IActionResult> CreateRating([FromBody] RatingDTO ratingDTO)
        {
            if (ratingDTO == null)
            {
                return BadRequest("Rating data is null.");
            }

            var result = await _ratingService.CreateRatingAsync(ratingDTO);
            if (!result)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return CreatedAtAction(nameof(GetRatingById), new { id = ratingDTO.Id }, ratingDTO);
        }

        // PUT: api/Rating/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRating(int id, [FromBody] RatingDTO ratingDTO)
        {
            if (ratingDTO == null)
            {
                return BadRequest("Rating data is null.");
            }

            var result = await _ratingService.UpdateRatingAsync(id, ratingDTO);
            if (!result)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        // DELETE: api/Rating/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            var result = await _ratingService.DeleteRatingAsync(id);
            if (!result)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }
    }
}
