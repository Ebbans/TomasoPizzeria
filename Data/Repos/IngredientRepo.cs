using Inlämning1Tomaso.Data.Interface.Repositories;
using Inlämning1Tomaso.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Inlämning1Tomaso.Data.Repos
{
    public class IngredientRepo : IIngredientRepo
    {
        private readonly TomasoDbContext _context;

        public IngredientRepo(TomasoDbContext context)
        {
            _context = context;
        }

        // Skapa en ny ingrediens
        public void AddIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
        }

        // Ta bort en ingrediens
        public void DeleteIngredient(int ingredientID)
        {
            var ingredient = _context.Ingredients
                .Include(i => i.DishIngredients) // Hämta eventuella kopplingar till rätter
                .FirstOrDefault(i => i.IngredientID == ingredientID);

            if (ingredient != null)
            {
                // Ta bort kopplingar i mellan-tabellen först
                _context.DishIngredients.RemoveRange(ingredient.DishIngredients);

                _context.Ingredients.Remove(ingredient);
                _context.SaveChanges();
            }
        }

        // Hämta alla ingredienser för en specifik rätt
        public List<Ingredient> GetAllDishIngredients(int dishID)
        {
            return _context.DishIngredients
                .Where(di => di.DishID == dishID)
                .Include(di => di.Ingredient)
                .Select(di => di.Ingredient)
                .ToList();
        }

        // Hämta alla ingredienser
        public List<Ingredient> GetAllIngredients()
        {
            return _context.Ingredients
                .Include(i => i.DishIngredients)
                    .ThenInclude(di => di.Dish)  // Inkludera rätterna varje ingrediens är kopplad till
                .ToList();
        }

        // Uppdatera en ingrediens
        public void UpdateIngredient(Ingredient ingredient)
        {
            var existing = _context.Ingredients.SingleOrDefault(i => i.IngredientID == ingredient.IngredientID);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(ingredient);
                _context.SaveChanges();
            }
        }

        // Hämta en specifik ingrediens (om det behövs)
        public Ingredient GetIngredient(int ingredientID)
        {
            return _context.Ingredients
                .Include(i => i.DishIngredients)
                    .ThenInclude(di => di.Dish)  // Inkludera alla rätter som ingrediensen tillhör
                .FirstOrDefault(i => i.IngredientID == ingredientID);
        }

       
    }
}
