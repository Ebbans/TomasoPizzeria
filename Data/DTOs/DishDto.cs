namespace Inlämning1Tomaso.Data.DTOs
{
    public class DishDto
    {
      
            public int DishID { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }

            // Visa ev. kategori eller ingredienser om du vill
            public List<string> Ingredients { get; set; }
        

    }
}
