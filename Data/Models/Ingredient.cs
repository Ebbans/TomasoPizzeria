using Inlämning1Tomaso.Data.Models;
using System.ComponentModel.DataAnnotations;

public class Ingredient
{
    [Key]
    public int IngredientID { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int DishID { get; set; }  // 👈 FK till Dish

    public Dish Dish { get; set; }   // 👈 Navigering tillbaka till Dish
}
