using Inlämning1Tomaso.Data.DTOs;
using Inlämning1Tomaso.Data.Interface.Repositories;
using Inlämning1Tomaso.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Inlämning1Tomaso.Data.Repos
{
    public class DishRepo : IDishRepo
    {
        private readonly TomasoDbContext _context;

        public DishRepo(TomasoDbContext context)
        {
            _context = context;
        }

        public DishIngredientsDto GetDishIngredients(int dishId)
        {
            var dish = _context.Dishes
                .Include(d => d.Ingredients)
                .FirstOrDefault(d => d.DishID == dishId);

            if (dish == null) return null;

            return new DishIngredientsDto
            {
                DishID = dish.DishID,
                DishName = dish.DishName,
                Description = dish.Description,
                Price = dish.Price,
                Ingredients = dish.Ingredients.Select(i => new IngredientDto
                {
                    IngredientID = i.IngredientID,
                    Name = i.Name
                }).ToList()
            };
        }
    }
}
