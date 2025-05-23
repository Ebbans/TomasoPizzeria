using Inlämning1Tomaso.Data.DTOs;

namespace Inlämning1Tomaso.Data.Interface.Services
{
    public interface IOrderService
    {
        OrderDto AddOrder(CreateOrderDto dto, int userId);

        List<OrderDto> GetAllOrders(int userId);
    }

}

