using System.ComponentModel.DataAnnotations.Schema;

namespace Inlämning1Tomaso.Data.Models
{
    public class DishIngredient
    {
        public int DishID { get; set; }
        public int IngredientID { get; set; }

        // Nav prop
        public Dish Dish { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
