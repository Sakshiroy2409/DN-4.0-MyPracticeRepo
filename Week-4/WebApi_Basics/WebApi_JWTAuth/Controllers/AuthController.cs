using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi_JWTAuth.Models;

namespace WebApi_JWTAuth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private List<UserModel> _users = new()
        {
            new UserModel { Username = "admin", Password = "admin123", Role = "Admin" },
            new UserModel { Username = "user", Password = "user123", Role = "User" }
        };

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            var user = _users.SingleOrDefault(x =>
                x.Username == login.Username && x.Password == login.Password);

            if (user == null)
                return Unauthorized("Invalid credentials");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("This is my super secret key");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return Ok(jwt);
        }
    }
}