using Inlämning1Tomaso.Data.DTOs;
using Inlämning1Tomaso.Data.Models;

namespace Inlämning1Tomaso.Data.Interface.Repositories
{
    public interface IDishRepo
    {
        DishIngredientsDto GetDishIngredients(int dishId);

    }
}
