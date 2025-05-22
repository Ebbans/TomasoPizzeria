using System.ComponentModel.DataAnnotations;

namespace Inlämning1Tomaso.Data.Models
{
    public class Dish
    {
        [Key]
        public int DishID { get; set; }
        [Required]

        [StringLength(50)]
        public string ?DishName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [StringLength(300)]

        public string ?Description { get; set; }
        [Required]

        
        public int CategoryID { get; set; }      // FK till Category
        [Required]
        public Category ?Category { get; set; }   // Navigeringsproperty
        public List <Ingredient> ?Ingredients { get; set; }

        public List<OrderDish> ?OrderDishes { get; set; } //Maträtt som förekommer i flera beställningar






    }

}
