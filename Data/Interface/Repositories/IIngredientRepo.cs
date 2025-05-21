using Inlämning1Tomaso.Data.Models;
using System.Collections.Generic;

namespace Inlämning1Tomaso.Data.Interface.Repositories
{
    public interface IIngredientRepo
    {
        void AddIngredient(Ingredient ingredient);
        void DeleteIngredient(int ingredientID);
        void UpdateIngredient(Ingredient ingredient);
        List<Ingredient> GetAllIngredients(); 
    }
}
