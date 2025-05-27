namespace Inlämning1Tomaso.Data.DTOs
{
    public class DishIngredientsDto
    {
        public int DishID { get; set; }
        public string DishName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public List<IngredientDto> Ingredients { get; set; }
        

    }
}
