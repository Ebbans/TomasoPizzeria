using Inlämning1Tomaso.Data.Interface.Repositories;
using Inlämning1Tomaso.Data.Interface.Services;

namespace Inlämning1Tomaso.Data.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepo _ingredientRepo;

        public IngredientService(IIngredientRepo ingredientRepo)
        {
            _ingredientRepo = ingredientRepo;
        }

        //public void AddIngredient(Ingredient ingredient)
        //{
        //    _ingredientRepo.AddIngredient(ingredient);
        //}

        //public void DeleteIngredient(int ingredientID)
        //{
        //    _ingredientRepo.DeleteIngredient(ingredientID);
        //}

        //public void UpdateIngredient(Ingredient ingredient)
        //{
        //    _ingredientRepo.UpdateIngredient(ingredient);
        //}

        public List<Ingredient> GetAllIngredients()
        {
            return _ingredientRepo.GetAllIngredients();
        }
    }
}
