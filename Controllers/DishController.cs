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


        [HttpGet]
        public IActionResult GetAll()
        {
            var dishes = _dishService.GetAllDishes();

            if (dishes == null || !dishes.Any())
            {
                return NotFound("Inga maträtter hittades.");
            }

            return Ok(dishes);
        }


    }
}
