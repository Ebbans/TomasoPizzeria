namespace Inlämning1Tomaso.Data.Models
{
    public class OrderDish
    {
        public int OrderID { get; set; }
        public int DishID { get; set; }

        //Navprop

        public Order ?Order { get; set; }
        public Dish Dish { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
