using Inlämning1Tomaso.Data.Interface.Repositories;
using Inlämning1Tomaso.Data.Interface.Services;
using Inlämning1Tomaso.Data.Models;
using System.Collections.Generic;

namespace Inlämning1Tomaso.Data.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepo _ingredientRepo;

        public IngredientService(IIngredientRepo ingredientRepo)
        {
            _ingredientRepo = ingredientRepo;
        }

        // Lägg till en ny ingrediens
        public void AddIngredient(Ingredient ingredient)
        {
            _ingredientRepo.AddIngredient(ingredient);
        }

        // Ta bort en ingrediens
        public void DeleteIngredient(int ingredientID)
        {
            _ingredientRepo.DeleteIngredient(ingredientID);
        }

        // Uppdatera en ingrediens
        public void UpdateIngredient(Ingredient ingredient)
        {
            _ingredientRepo.UpdateIngredient(ingredient);
        }

        // Hämta alla ingredienser
        public List<Ingredient> GetAllIngredients()
        {
            return _ingredientRepo.GetAllIngredients();
        }
    }
}
