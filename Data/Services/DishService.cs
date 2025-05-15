using Inlämning1Tomaso.Data.Interface.Repositories;
using Inlämning1Tomaso.Data.Interface.Services;
using Inlämning1Tomaso.Data.Models;
using Inlämning1Tomaso.Data.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Inlämning1Tomaso.Data.Services
{
    public class DishService : IDishService
    {
        private readonly IDishRepo _dishRepo;

        public DishService(IDishRepo dishRepo)
        {
            _dishRepo = dishRepo;
        }

        public void AddDish(Dish dish)
        {
            _dishRepo.AddDish(dish);
        }

        public void DeleteDish(int dishID)
        {
            _dishRepo.DeleteDish(dishID);
        }

        public void UpdateDish(Dish dish)
        {
            _dishRepo.UpdateDish(dish);
        }

        public List<DishDto> GetAllDishes()
        {
            var dishes = _dishRepo.GetAllDishes();

            var dishDtos = dishes.Select(d => new DishDto
            {
                DishID = d.DishID,
                Name = d.DishName,
                Price = d.Price
            }).ToList();

            return dishDtos;
        }

    }
}
