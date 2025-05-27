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

        public List<Ingredient> GetAllIngredients()
        {
            return _ingredientRepo.GetAllIngredients();
        }
    }
}
