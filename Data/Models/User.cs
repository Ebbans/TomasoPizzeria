using System.ComponentModel.DataAnnotations;

namespace Inlämning1Tomaso.Data.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]

        [StringLength(50)] 
        public string UserName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength (50)]
        public string Password { get; set; }

        [Phone]
        public int Phone { get; set; }




    }
}
