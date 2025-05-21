using Inlämning1Tomaso.Data.Interface.Repositories;
using Inlämning1Tomaso.Data.Models;
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

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userID)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserID == userID);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public void UpdateUser(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.UserID == user.UserID);
            if (existingUser != null)
            {
                _context.Entry(existingUser).CurrentValues.SetValues(user);
                _context.SaveChanges();
            }
        }

        public User GetUserById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.UserID == userId);
        }
    }
}
