using Inlämning1Tomaso.Data.DTOs;
using System.Collections.Generic;

public interface IOrderService
{
    OrderDto AddOrder(CreateOrderDto dto, int userId);

    List<OrderDto> GetAllOrders(int userId);
}
