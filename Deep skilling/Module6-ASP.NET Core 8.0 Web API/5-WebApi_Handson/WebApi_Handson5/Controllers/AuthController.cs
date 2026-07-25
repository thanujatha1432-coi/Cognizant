using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebApi_Handson5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private const string SecurityKey =
            "mysuperdupersecretkey123456789012345";

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GenerateToken()
        {
            string token = GenerateJsonWebToken(
                userId: 1,
                userRole: "Admin"
            );

            return Ok(new
            {
                Token = token,
                UserId = 1,
                Role = "Admin",
                ExpiresInMinutes = 2
            });
        }

        private string GenerateJsonWebToken(
            int userId,
            string userRole)
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(SecurityKey)
            );

            var credentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256
            );

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, userRole),
                new Claim("UserId", userId.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "mySystem",
                audience: "myUsers",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}
