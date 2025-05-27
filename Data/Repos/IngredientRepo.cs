using Inlämning1Tomaso.Data.Interface.Repositories;

namespace Inlämning1Tomaso.Data.Repos
{
    public class IngredientRepo : IIngredientRepo
    {
        private readonly TomasoDbContext _context;

        public IngredientRepo(TomasoDbContext context)
        {
            _context = context;
        }

        public List<Ingredient> GetAllIngredients()
        {
            return _context.Ingredients.ToList();
        }
    }
}
