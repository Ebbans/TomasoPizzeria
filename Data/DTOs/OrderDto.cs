
public class OrderDto
{
    public int OrderID { get; set; }
    public int UserID { get; set; }
    public string UserName { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Price { get; set; }
    public List<OrderDishDto> Dishes { get; set; }  // valfritt men bra
}
