using Inlämning1Tomaso.Data.DTOs;

namespace Inlämning1Tomaso.Data.Interface.Repositories
{
    public interface IDishRepo
    {
        DishIngredientsDto GetDishIngredients(int dishId);

    }
}
