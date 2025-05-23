using Inlämning1Tomaso.Data.Models;

namespace Inlämning1Tomaso.Data.Repos
{
    public class OrderDishRepo
    {
        public int OrderID { get; set; }
        public int DishID { get; set; }

        //Navprop

        public Order ?Order { get; set; }

        public Dish ?Dish { get; set; } 
    }
}
