using Inlämning1Tomaso.Data.Models;
using Inlämning1Tomaso.Data.DTOs;
using System.Collections.Generic;

namespace Inlämning1Tomaso.Data.Interface.Services
{
    public interface IDishService
    {
        List<DishDto> GetAllDishes();
    }
}
