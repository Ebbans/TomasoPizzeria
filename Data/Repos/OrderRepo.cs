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

        // Ta bort en beställning
        public void DeleteOrder(int orderID)
        {
            var order = _context.Orders
                .Include(o => o.OrderDishes)
                .FirstOrDefault(o => o.OrderID == orderID);

            if (order != null)
            {
                // Ta bort kopplingar till rätter först (OrderDish-poster)
                _context.RemoveRange(order.OrderDishes);

                // Ta bort själva beställningen
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public List<Order> GetAllOrders(int orderID)
        {
            return _context.Orders
                            .Include(o => o.OrderDishes)  // Inkludera OrderDishes för att få alla rätter för varje beställning
                            .ToList();
        }
    }
}