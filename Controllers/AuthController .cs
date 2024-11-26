using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.Controllers
{
    // Controllers/AuthController.cs
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterDto dto)
        {
            if (!_authService.Register(new User { Username = dto.Username }, dto.Password))
                return BadRequest("User already exists.");

            return Ok("User registered.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto dto)
        {
            var token = _authService.Authenticate(dto.Username, dto.Password);
            if (token == null) return Unauthorized("Invalid credentials.");

            return Ok(new { Token = token });
        }
    }

    // DTOs for simplicity
    public class UserRegisterDto { public string Username { get; set; } public string Password { get; set; } }
    public class UserLoginDto { public string Username { get; set; } public string Password { get; set; } }

}
