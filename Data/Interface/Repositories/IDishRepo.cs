using Inlämning1Tomaso.Data.Models;

namespace Inlämning1Tomaso.Data.Interface.Repositories
{
    public interface IDishRepo
    {
        void AddDish(Dish dish);

        void UpdateDish (Dish dish);

        void DeleteDish(int dishID);

        List<Dish> GetAllDishes();

    }
}
