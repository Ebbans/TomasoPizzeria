using System.ComponentModel.DataAnnotations;

namespace Inlämning1Tomaso.Data.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]

        [StringLength(50)]
        public string CategoryName { get; set; }

        public List<Dish> Dishes { get; set; }

    }
}
 