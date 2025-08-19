using Microsoft.AspNetCore.Mvc;

namespace ChatServer
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _auth;

        public AuthController(AuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("register")]
        public IActionResult Register([FromForm] string username, [FromForm] string password)
        {
            try
            {
                if (_auth.Register(username, password))
                    return Ok("Registered");
                return BadRequest("User already exists");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal error: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            if (_auth.Login(username, password))
                return Ok("Logged in");
            return Unauthorized();
        }
    } 
}
