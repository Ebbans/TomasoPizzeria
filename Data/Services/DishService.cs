using Inlämning1Tomaso.Data.DTOs;
using Inlämning1Tomaso.Data.Interface.Repositories;
using Inlämning1Tomaso.Data.Interface.Services;

namespace Inlämning1Tomaso.Data.Services
{
    public class DishService : IDishService
    {
        private readonly IDishRepo _dishRepo;

        public DishService(IDishRepo dishRepo)
        {
            _dishRepo = dishRepo;
        }

        public DishIngredientsDto GetDishIngredients(int dishId)
        {
            return _dishRepo.GetDishIngredients(dishId);
        }
    }
}
