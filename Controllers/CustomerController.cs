using Inlämning1Tomaso.Data.DTOs;
using Inlämning1Tomaso.Data.Models;
using Inlämning1Tomaso.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inlämning1Tomaso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
            private readonly TomasoDbContext _context;

            public CustomerController(TomasoDbContext context)
            {
                _context = context;
            }

            // GET: api/Customer
            [HttpGet]
            public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
            {
                var customers = await _context.Customers
                    .Select(c => new CustomerDto
                    {
                        CustomerID = c.CustomerID,
                        CustomerName = c.CustomerName,
                        Email = c.Email
                    })
                    .ToListAsync();

                return customers;
            }

            // GET: api/Customer/5
            [HttpGet("{id}")]
            public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
            {
                var customer = await _context.Customers.FindAsync(id);

                if (customer == null)
                    return NotFound();

                var dto = new CustomerDto
                {
                    CustomerID = customer.CustomerID,
                    CustomerName = customer.CustomerName,
                    Email = customer.Email
                };

                return dto;
            }

            // POST: api/Customer
            [HttpPost]
            public async Task<ActionResult<CustomerDto>> PostCustomer(CustomerDto dto)
            {
                var customer = new Customer
                {
                    CustomerName = dto.CustomerName,
                    Email = dto.Email
                    // Du kan lägga till defaultvärden eller generera lösenord om det behövs
                };

                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();

                dto.CustomerID = customer.CustomerID;

                return CreatedAtAction(nameof(GetCustomer), new { id = dto.CustomerID }, dto);
            }

            // PUT: api/Customer/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutCustomer(int id, CustomerDto dto)
            {
                if (id != dto.CustomerID)
                    return BadRequest();

                var customer = await _context.Customers.FindAsync(id);
                if (customer == null)
                    return NotFound();

                customer.CustomerName = dto.CustomerName;
                customer.Email = dto.Email;

                await _context.SaveChangesAsync();
                return NoContent();
            }

            // DELETE: api/Customer/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCustomer(int id)
            {
                var customer = await _context.Customers.FindAsync(id);
                if (customer == null)
                    return NotFound();

                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();

                return NoContent();
            }
        
    }

}

