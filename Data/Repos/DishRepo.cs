using Inlämning1Tomaso.Data.Interface.Repositories;
using Inlämning1Tomaso.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Inlämning1Tomaso.Data.Repos
{
    public class DishRepo : IDishRepo
    {
        private readonly TomasoDbContext _context;

        public DishRepo(TomasoDbContext context)
        {
            _context = context;
        }

        //public void AddDish(Dish dish)
        //{
        //    _context.Dishes.Add(dish);
        //    _context.SaveChanges();
        //}

        //public void DeleteDish(int dishID)
        //{
        //    var dish = _context.Dishes.SingleOrDefault(d => d.DishID == dishID);
        //    if (dish != null)
        //    {
        //        _context.Dishes.Remove(dish);
        //        _context.SaveChanges();
        //    }
        //}

        //public void UpdateDish(Dish dish)
        //{
        //    var existingDish = _context.Dishes.SingleOrDefault(d => d.DishID == dish.DishID);
        //    if (existingDish != null)
        //    {
        //        _context.Entry(existingDish).CurrentValues.SetValues(dish);
        //        _context.SaveChanges();
        //    }
        //}
       

        public List<Dish> GetAllDishes()
        {
            return _context.Dishes.ToList();
        }
    }
}
