using Inlämning1Tomaso.Data.DTOs;
using Inlämning1Tomaso.Data.Interface.Repositories;
using Inlämning1Tomaso.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Inlämning1Tomaso.Data.Repos
{
    public class OrderRepo : IOrderRepo
    {
        private readonly TomasoDbContext _context;

        public OrderRepo(TomasoDbContext context)
        {
            _context = context;
        }

        // Skapa en ny beställning
        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public OrderDto AddOrder(CreateOrderDto dto, int userId)
        {
            throw new NotImplementedException();
        }

        

        public List<Order> GetAllOrders(int orderID)
        {
            return _context.Orders
                            .Include(o => o.OrderDishes)  // Inkludera OrderDishes för att få alla rätter för varje beställning
                            .ToList();
        }

        public List<Order> GetAllOrdersByUserId(int userId)
        {
            return _context.Orders
       .Include(o => o.OrderDishes)
       .Where(o => o.UserID == userId)
       .ToList();
        }
    }
}