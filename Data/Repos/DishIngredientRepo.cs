using Inlämning1Tomaso.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Inlämning1Tomaso.Data.Repos
{
    public class DishIngredientRepo
    {
        private readonly TomasoDbContext _context;

        public DishIngredientRepo(TomasoDbContext context)
        {
            _context = context;
        }

        public void AddDishIngredient(DishIngredient dishIngredient)
        {
            _context.DishIngredients.Add(dishIngredient);
            _context.SaveChanges();
        }

        public void DeleteDishIngredient(int dishID, int ingredientID)
        {
            var relation = _context.DishIngredients
                .FirstOrDefault(di => di.DishID == dishID && di.IngredientID == ingredientID);

            if (relation != null)
            {
                _context.DishIngredients.Remove(relation);
                _context.SaveChanges();
            }
        }

        public List<Ingredient> GetIngredientsByDishId(int dishID)
        {
            return _context.DishIngredients
                .Where(di => di.DishID == dishID)
                .Include(di => di.Ingredient)
                .Select(di => di.Ingredient)
                .ToList();
        }

        public List<Dish> GetDishesByIngredientId(int ingredientID)
        {
            return _context.DishIngredients
                .Where(di => di.IngredientID == ingredientID)
                .Include(di => di.Dish)
                .Select(di => di.Dish)
                .ToList();
        }
    }
}
