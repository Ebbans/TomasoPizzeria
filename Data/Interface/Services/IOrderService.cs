using Inlämning1Tomaso.Data.DTOs;
using Inlämning1Tomaso.Data.Models;
using System.Collections.Generic;

namespace Inlämning1Tomaso.Data.Interface.Services
{
    public interface IOrderService
    {
        void AddOrder(Order order);
        void DeleteOrder(int orderID);
        List<OrderDto> GetAllOrders(int userID);
    }
}
