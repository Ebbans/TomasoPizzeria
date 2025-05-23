using Inlämning1Tomaso.Data.Models;

namespace Inlämning1Tomaso.Data.DTOs
{
    public class DishDto
    {
        public int DishID { get; set; }
        public string ?Name { get; set; }
        public decimal Price { get; set; }
        public CategoryDto ?Category { get; set; }
        public List<IngredientDto> ?Ingredients { get; set; }


    }
}
