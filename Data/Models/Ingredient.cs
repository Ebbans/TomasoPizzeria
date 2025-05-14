using System.ComponentModel.DataAnnotations;

namespace Inlämning1Tomaso.Data.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public List<Dish> Dishes { get; set; } //Ingrediens kan ingå i många maträtter (M:M)
        public List<DishIngredient> DishIngredients { get; set; } // M:M-relation
    }
}
