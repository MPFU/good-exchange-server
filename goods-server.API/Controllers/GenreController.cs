using goods_server.Contracts;
using goods_server.Service.InterfaceService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goods_server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // GET: api/Genre/name
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetGenreByName(string name)
        {
            var genre = await _genreService.GetGenreByNameAsync(name);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        // GET: api/Genre/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        // GET: api/Genre
        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _genreService.GetAllGenresAsync();
            return Ok(genres);
        }

        // POST: api/Genre
        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] GenreDTO genreDTO)
        {
            if (genreDTO == null)
            {
                return BadRequest("Genre data is null.");
            }

            var result = await _genreService.CreateGenreAsync(genreDTO);
            if (!result)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return CreatedAtAction(nameof(GetGenreById), new { id = genreDTO.GenreId }, genreDTO);
        }

        // PUT: api/Genre/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id, [FromBody] GenreDTO genreDTO)
        {
            if (genreDTO == null)
            {
                return BadRequest("Genre data is null.");
            }

            var result = await _genreService.UpdateGenreAsync(id, genreDTO);
            if (!result)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        // DELETE: api/Genre/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var result = await _genreService.DeleteGenreAsync(id);
            if (!result)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }
    }
}
