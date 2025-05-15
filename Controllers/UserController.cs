using Inlämning1Tomaso.Data.DTOs;
using Inlämning1Tomaso.Data.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inlämning1Tomaso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

       

       
    }
}
