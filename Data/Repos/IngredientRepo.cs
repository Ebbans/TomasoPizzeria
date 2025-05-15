using Inlämning1Tomaso.Data.Models;
using Inlämning1Tomaso.Data.Interface.Repositories;
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

        // Lägg till en ingrediens
        public void AddIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
        }

        // Ta bort en ingrediens
        public void DeleteIngredient(int ingredientID)
        {
            var ingredient = _context.Ingredients.SingleOrDefault(i => i.IngredientID == ingredientID);
            if (ingredient != null)
            {
                _context.Ingredients.Remove(ingredient);
                _context.SaveChanges();
            }
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

        // Hämta alla ingredienser
        public List<Ingredient> GetAllIngredients()
        {
            return _context.Ingredients.ToList();
        }
    }
}
