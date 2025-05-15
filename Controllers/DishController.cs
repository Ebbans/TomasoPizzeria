using Inlämning1Tomaso.Data.Interface.Services;
using Inlämning1Tomaso.Data.Models;
using Inlämning1Tomaso.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Inlämning1Tomaso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        // GET: api/dish
        [HttpGet]
        public ActionResult<List<DishDto>> GetAll()
        {
            var dishes = _dishService.GetAllDishes();
            return Ok(dishes);
        }

        // POST: api/dish
        [HttpPost]
        public ActionResult AddDish([FromBody] Dish dish)
        {
            _dishService.AddDish(dish);
            return CreatedAtAction(nameof(GetAll), new { id = dish.DishID }, dish);
        }

        // PUT: api/dish
        [HttpPut]
        public IActionResult UpdateDish([FromBody] Dish dish)
        {
            _dishService.UpdateDish(dish);
            return NoContent();
        }

        // DELETE: api/dish/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteDish(int id)
        {
            _dishService.DeleteDish(id);
            return NoContent();
        }
    }
}
