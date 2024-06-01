using goods_server.Contracts;
using goods_server.Service.InterfaceService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace goods_server.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Category/name
        [HttpGet("{name}")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            try
            {
                var category = await _categoryService.GetCategoryByNameAsync(name);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch (ApplicationException ex)
            {
                // Log the exception (if logging is configured)
                // Log.Error(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch (ApplicationException ex)
            {
                // Log the exception (if logging is configured)
                // Log.Error(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/Category
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync();
                return Ok(categories);
            }
            catch (ApplicationException ex)
            {
                // Log the exception (if logging is configured)
                // Log.Error(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Category
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return BadRequest("Category data is null.");
            }

            try
            {
                var result = await _categoryService.CreateCategoryAsync(categoryDTO);
                if (!result)
                {
                    return StatusCode(500, "A problem happened while handling your request.");
                }

                return CreatedAtAction(nameof(GetCategoryById), new { id = categoryDTO.Name }, categoryDTO);
            }
            catch (ApplicationException ex)
            {
                // Log the exception (if logging is configured)
                // Log.Error(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return BadRequest("Category data is null.");
            }

            try
            {
                var result = await _categoryService.UpdateCategoryAsync(id, categoryDTO);
                if (!result)
                {
                    return StatusCode(500, "A problem happened while handling your request.");
                }

                return NoContent();
            }
            catch (ApplicationException ex)
            {
                // Log the exception (if logging is configured)
                // Log.Error(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var result = await _categoryService.DeleteCategoryAsync(id);
                if (!result)
                {
                    return StatusCode(500, "A problem happened while handling your request.");
                }

                return NoContent();
            }
            catch (ApplicationException ex)
            {
                // Log the exception (if logging is configured)
                // Log.Error(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
