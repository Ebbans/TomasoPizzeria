using Inlämning1Tomaso.Data.DTOs;

namespace Inlämning1Tomaso.Data.Interface.Services
{
    public interface IDishService
    {
        DishIngredientsDto GetDishIngredients(int dishId);
    }

}
