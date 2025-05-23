using Inlämning1Tomaso.Data.Models;
namespace Inlämning1Tomaso.Data.Interface.Repositories
{
    public interface IOrderRepo
    {
        void AddOrder(Order order);
        List<Order> GetAllOrdersByUserId(int userId);
    }
}

