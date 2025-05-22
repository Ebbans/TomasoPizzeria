namespace Inlämning1Tomaso.Data.DTOs
{
    public class CreateOrderDto
    {
        public List<DishOrderItemDto> ?Dishes { get; set; }
    }

    public class DishOrderItemDto
    {
        public int DishID { get; set; }
        public int Quantity { get; set; }
    }
}
