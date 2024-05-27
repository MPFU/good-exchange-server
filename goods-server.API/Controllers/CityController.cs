using goods_server.Contracts;
using goods_server.Service.InterfaceService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goods_server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET: api/City/name
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetCityByName(string name)
        {
            var city = await _cityService.GetCityByNameAsync(name);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        // GET: api/City/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var city = await _cityService.GetCityByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        // GET: api/City
        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await _cityService.GetAllCitiesAsync();
            return Ok(cities);
        }

        // POST: api/City
        [HttpPost]
        public async Task<IActionResult> CreateCity([FromBody] CityDTO cityDTO)
        {
            if (cityDTO == null)
            {
                return BadRequest("City data is null.");
            }

            var result = await _cityService.CreateCityAsync(cityDTO);
            if (!result)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return CreatedAtAction(nameof(GetCityById), new { id = cityDTO.CityId }, cityDTO);
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity(int id, [FromBody] CityDTO cityDTO)
        {
            if (cityDTO == null)
            {
                return BadRequest("City data is null.");
            }

            var result = await _cityService.UpdateCityAsync(id, cityDTO);
            if (!result)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        // DELETE: api/City/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var result = await _cityService.DeleteCityAsync(id);
            if (!result)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }
    }
}
