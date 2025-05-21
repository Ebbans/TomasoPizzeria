using Inlämning1Tomaso.Data.Interface.Services;
using Inlämning1Tomaso.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Inlämning1Tomaso.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        
        [HttpGet]
        public ActionResult<List<Ingredient>> GetIngredients()
        {
            var ingredients = _ingredientService.GetAllIngredients();
            return Ok(ingredients);
        }

    //    // POST: api/Ingredient
    //    [HttpPost]
    //    public ActionResult<Ingredient> PostIngredient(Ingredient ingredient)
    //    {
    //        _ingredientService.AddIngredient(ingredient);
    //        return CreatedAtAction(nameof(GetIngredients), new { id = ingredient.IngredientID }, ingredient);
    //    }

    //    // PUT: api/Ingredient/5
    //    [HttpPut("{id}")]
    //    public IActionResult PutIngredient(int id, Ingredient ingredient)
    //    {
    //        if (id != ingredient.IngredientID)
    //        {
    //            return BadRequest();
    //        }

    //        _ingredientService.UpdateIngredient(ingredient);
    //        return NoContent();
    //    }

    //    // DELETE: api/Ingredient/5
    //    [HttpDelete("{id}")]
    //    public IActionResult DeleteIngredient(int id)
    //    {
    //        _ingredientService.DeleteIngredient(id);
    //        return NoContent();
    //    }
    //
    }
}
