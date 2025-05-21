using Inlämning1Tomaso.Data.DTOs;
using Inlämning1Tomaso.Data.Interface.Services;
using Inlämning1Tomaso.Data.Keys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpPost("register")]
        public IActionResult Register([FromBody] CreateUserDto dto)
        {
            var success = _userService.CreateUser(dto);
            if (!success)
                return BadRequest("Email already exsist");

            return Ok("User is created");
        }

        
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDto dto)
        {
            var token = _userService.Authenticate(dto.UserName, dto.Password);
            if (token == null)
                return Unauthorized("Invalid Email or password");

            return Ok(new { Token = token });
        }

        
        [Authorize]
        [HttpGet("me")]
        public IActionResult GetMyUser()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            int userId = int.Parse(userIdClaim.Value);

            var user = _userService.GetById(userId);
            if (user == null)
                return NotFound();

            var userDto = new GetUserDto
            {
                UserID = user.UserID,
                UserName = user.UserName
                
            };

            return Ok(userDto);
        }


        [Authorize]
        [HttpPut("Update")]
        public IActionResult UpdateMyUser([FromBody] CreateUserDto dto)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier); // Ändrat
            if (!int.TryParse(userIdString, out var userId))
                return Unauthorized();

            _userService.UpdateUser(userId, dto);
            return Ok("The user is updated");
        }

        [Authorize]
        [HttpDelete("Delete")]
        public IActionResult DeleteMyUser()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier); // Ändrat
            if (!int.TryParse(userIdString, out var userId))
                return Unauthorized();

            _userService.DeleteUser(userId);
            return Ok("The user is removed");
        }

    }
}
