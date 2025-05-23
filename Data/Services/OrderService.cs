using Inlämning1Tomaso.Data.DTOs;
using Inlämning1Tomaso.Data.Interface.Repositories;
using Inlämning1Tomaso.Data.Interface.Services;
using Inlämning1Tomaso.Data.Models;
using Inlämning1Tomaso.Data;

public class OrderService : IOrderService
{
    private readonly IOrderRepo _orderRepo;
    private readonly TomasoDbContext _context;

    public OrderService(IOrderRepo orderRepo, TomasoDbContext context)
    {
        _orderRepo = orderRepo;
        _context = context;
    }

    public List<OrderDto> GetAllOrders(int userId)
    {
        var orders = _orderRepo.GetAllOrdersByUserId(userId);

        return orders.Select(o => new OrderDto
        {
            OrderID = o.OrderID,
            UserID = o.UserID,
            UserName = _context.Users.Find(o.UserID)?.UserName,
            OrderDate = o.OrderDate,
            Price = o.TotalPrice,
            Dishes = o.OrderDishes.Select(od => new OrderDishDto
            {
                DishID = od.DishID,
                Name = _context.Dishes.Find(od.DishID)?.DishName, 
                Quantity = od.Quantity,
                Price = od.Price
            }).ToList()
        }).ToList();
    }

    public OrderDto AddOrder(CreateOrderDto dto, int userId)
    {
        var order = new Order
        {
            UserID = userId,
            OrderDate = DateTime.UtcNow,
            OrderDishes = new List<OrderDish>()
        };

        decimal total = 0;

        foreach (var item in dto.Dishes)
        {
            var dish = _context.Dishes.Find(item.DishID);
            if (dish == null) continue;

            var orderDish = new OrderDish
            {
                DishID = dish.DishID,
                Quantity = item.Quantity,
                Price = dish.Price * item.Quantity
            };

            order.OrderDishes.Add(orderDish);
            total += orderDish.Price;
        }

        order.TotalPrice = total;

        _orderRepo.AddOrder(order);
        

        return new OrderDto
        {
            OrderID = order.OrderID,
            UserID = order.UserID,
            UserName = _context.Users.Find(userId)?.UserName,
            OrderDate = order.OrderDate,
            Price = order.TotalPrice,
            Dishes = order.OrderDishes.Select(od => new OrderDishDto
            {
                DishID = od.DishID,
                Name = _context.Dishes.Find(od.DishID)?.DishName,  // Ändrat till DishName
                Quantity = od.Quantity,
                Price = od.Price
            }).ToList()
        };
    }
}
