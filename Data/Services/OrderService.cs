using Inlämning1Tomaso.Data.Interface.Repositories;
using Inlämning1Tomaso.Data.Interface.Services;
using Inlämning1Tomaso.Data.Models;
using Inlämning1Tomaso.Data.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Inlämning1Tomaso.Data.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        private readonly TomasoDbContext _context;

        public OrderService(IOrderRepo orderRepo, TomasoDbContext context)
        {
            _orderRepo = orderRepo;
            _context = context;
        }

        // Lägg till en ny order
        public void AddOrder(Order order)
        {
            _orderRepo.AddOrder(order); // Anropa repository för att lägga till order
        }

        // Ta bort en order
        public void DeleteOrder(int orderID)
        {
            _orderRepo.DeleteOrder(orderID); // Anropa repository för att ta bort order
        }

        // Hämta alla ordrar för en viss användare
        public List<OrderDto> GetAllOrders(int userID)
        {
            // Hämta alla ordrar för användaren, inklusive användardata
            var orders = _context.Orders
                .Where(o => o.UserID == userID)  // Filtrera ordrar baserat på användarens ID
                .Include(o => o.User)            // Ladda relaterad användardata
                .ToList();

            // Konvertera varje order till en OrderDto
            var orderDtos = orders.Select(order => new OrderDto
            {
                OrderID = order.OrderID,
                UserID = order.UserID,
                UserName = order.User?.UserName, // Hämta användarnamnet från den relaterade användaren
                OrderDate = order.OrderDate,
                Price = order.TotalPrice
            }).ToList();

            return orderDtos; // Returnera listan med DTO:er
        }
    }
}
