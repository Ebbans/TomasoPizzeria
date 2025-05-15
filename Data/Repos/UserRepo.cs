using Inlämning1Tomaso.Data.Interface.Repositories;
using Inlämning1Tomaso.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Inlämning1Tomaso.Data.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly TomasoDbContext _context;

        public UserRepo(TomasoDbContext context)
        {
            _context = context;
        }


        public void AddUSer(User user)
        {
            _context.Users.Add(user);  
            _context.SaveChanges();  
        }
        public void DeleteUser(int userID)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserID == userID);  // Hämta användaren
            if (user != null)
            {
                _context.Users.Remove(user);  // Ta bort användaren från Users-tabellen
                _context.SaveChanges();  // Spara ändringarna
            }
        }

        //public List<User> GetAllUsers()
        //{
        //   return  _context.Users.GettAllUsers();
        //}

        public void UpdateUser(User user)
        {
            var existingUser = _context.Users.SingleOrDefault(u => u.UserID == user.UserID);
            if (existingUser != null)
            {
                _context.Entry(existingUser).CurrentValues.SetValues(user);  // Uppdatera användarens värden
                _context.SaveChanges();  // Spara ändringarna
            }
        }
    }
}
