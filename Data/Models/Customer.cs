using System.ComponentModel.DataAnnotations;

namespace Inlämning1Tomaso.Data.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID {  get; set; }
        [Required]

        [StringLength(50)]
        public string CustomerName { get; set; }
        [Required]

        [StringLength(50)]
        public string Email {  get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [Phone]
        public int Phone {  get; set; }

        public List<Order> Orders { get; set; }


    }
}
