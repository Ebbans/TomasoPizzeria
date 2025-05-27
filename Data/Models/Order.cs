using System.ComponentModel.DataAnnotations;

namespace Inlämning1Tomaso.Data.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public int UserID { get; set; } 
        public User User { get; set; } //Nav prop till User

        public List<OrderDish> OrderDishes { get; set; } 

    }
}
