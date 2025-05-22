using Inlämning1Tomaso.Data.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inlämning1Tomaso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        [HttpGet("{id}/ingredients")]
        public IActionResult GetDishIngredients(int id)
        {
            var dish = _dishService.GetDishIngredients(id);
            if (dish == null)
                return NotFound();

            return Ok(dish);
        }
    }
}
