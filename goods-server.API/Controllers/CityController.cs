using goods_server.Contracts;
using goods_server.Service.InterfaceService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace goods_server.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET: api/City/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            try
            {
                var city = await _cityService.GetCityByIdAsync(id);
                if (city == null)
                {
                    return NotFound();
                }
                return Ok(city);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/City
        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            try
            {
                var cities = await _cityService.GetAllCitiesAsync();
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/City
        [HttpPost]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityDTO cityDTO)
        {
            if (cityDTO == null)
            {
                return BadRequest("City data is null.");
            }

            try
            {
                var result = await _cityService.CreateCityAsync(cityDTO);
                if (!result)
                {
                    return StatusCode(500, "A problem happened while handling your request.");
                }

                return CreatedAtAction(nameof(GetCityById), new { id = cityDTO.Name }, cityDTO);
            }
            catch (Exception ex)
            {
                return Conflict(new { Status = 409, Message = ex.Message });
            }
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity(int id, [FromBody] UpdateCityDTO cityDTO)
        {
            if (cityDTO == null)
            {
                return BadRequest("City data is null.");
            }

            try
            {
                var result = await _cityService.UpdateCityAsync(id, cityDTO);
                if (!result)
                {
                    return StatusCode(500, "A problem happened while handling your request.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/City/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            try
            {
                var result = await _cityService.DeleteCityAsync(id);
                if (!result)
                {
                    return StatusCode(500, "A problem happened while handling your request.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
