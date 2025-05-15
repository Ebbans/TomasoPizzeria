using Inlämning1Tomaso.Data.Models;
using System.Collections.Generic;

namespace Inlämning1Tomaso.Data.Interface.Services
{
    public interface IIngredientService
    {
        void AddIngredient(Ingredient ingredient); // Lägg till en ny ingrediens
        void DeleteIngredient(int ingredientID); // Ta bort en ingrediens
        void UpdateIngredient(Ingredient ingredient); // Uppdatera en ingrediens
        public List<Ingredient> GetAllIngredients(); // Hämta alla ingredienser
    }
}
