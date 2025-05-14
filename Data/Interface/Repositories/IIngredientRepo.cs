using Inlämning1Tomaso.Data.Models;

namespace Inlämning1Tomaso.Data.Interface.Repositories
{
    public interface IIngredientRepo
    {
        void AddIngredient(Ingredient ingredient);

        void DeleteIngredient(int ingredientID);

        void UpdateIngredient(Ingredient ingredient);

    }
}
