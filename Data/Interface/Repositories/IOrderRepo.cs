using Inlämning1Tomaso.Data.Models;

namespace Inlämning1Tomaso.Data.Interface.Repositories
{
    public interface IOrderRepo
    {
        void AddOrder(Order order);
        void DeleteOrder(int orderID);

        List <Order> GetAllOrders(int orderID);

    }
}
