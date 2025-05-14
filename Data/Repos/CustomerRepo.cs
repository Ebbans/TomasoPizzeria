using Inlämning1Tomaso.Data.Interface.Repositories;
using Inlämning1Tomaso.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Inlämning1Tomaso.Data.Repos
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly TomasoDbContext _context;

        public CustomerRepo(TomasoDbContext context)
        {
            _context = context;
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(int customerID)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerID == customerID);  // Hämta användaren
            if (customer != null)
            {
                _context.Customers.Remove(customer);  // Ta bort användaren från Users-tabellen
                _context.SaveChanges();  // Spara ändringarna
            }
        }

        public List<Customer> GetAllCustomer(int customerID)
        {
            return _context.Customers.ToList();
        }

        public void UpdateCustomer(Customer customer)
        {
            var existingCustomer = _context.Customers.SingleOrDefault(c => c.CustomerID == customer.CustomerID);
            if (existingCustomer != null)
            {
                _context.Entry(existingCustomer).CurrentValues.SetValues(customer);  // Uppdatera användarens värden
                _context.SaveChanges();  // Spara ändringarna
            }
        }
    } 
}
