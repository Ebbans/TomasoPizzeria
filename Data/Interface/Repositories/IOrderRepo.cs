using Inlämning1Tomaso.Data.Models;

public interface IOrderRepo
{
    void AddOrder(Order order);
    List<Order> GetAllOrdersByUserId(int userId);
}
