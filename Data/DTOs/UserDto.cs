using Inlämning1Tomaso.Data.Models;

namespace Inlämning1Tomaso.Data.DTOs
{
    public class UserDto
    {
        
            public int UserID { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
        
            public List<UserDto> Users { get; set; }

    }
}
