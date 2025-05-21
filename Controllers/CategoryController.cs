using Inlämning1Tomaso.Data.DTOs;
using Inlämning1Tomaso.Data.Interface.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inlämning1Tomaso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/category
        [HttpGet]
        public ActionResult<List<CategoryDto>> GetAll()
        {
            return Ok(_categoryService.GetAllCategories());
        }

        //[HttpPost]
        //public ActionResult<CategoryDto> CreateCategory([FromBody] CategoryDto categoryDto)
        //{
        //    if (categoryDto == null || string.IsNullOrWhiteSpace(categoryDto.CategoryName))
        //        return BadRequest("Category name is requested.");

        //    //var created = _categoryService.CreateCategory(categoryDto);

        //    //return CreatedAtAction(nameof(GetAll), new { id = created.CategoryID }, created);
        //}

    }
}

