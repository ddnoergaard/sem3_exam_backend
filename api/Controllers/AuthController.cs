using api.Models;                 // NY
using api.Repositories;           // NY
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AdminRepository _adminRepository;   // NY

        public AuthController(IConfiguration config, AdminRepository adminRepository)   // NY: AdminRepository tilføjet
        {
            _config = config;
            _adminRepository = adminRepository;   // NY
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest login)
        {
            // GAMMEL: hardcodet login - erstattet af AdminRepository herunder
            //if (login.Username == "admin" && login.Password == "1234")
            //{
            //    var token = GenerateJwtToken(login.Username);
            //    return Ok(new { token });
            //}
            //
            //return Unauthorized("Invalid username or password.");

            // NY: spørg AdminRepository om brugernavn og kodeord passer
            Admin? admin = _adminRepository.CheckLogin(login.Username, login.Password);

            if (admin == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            var token = GenerateJwtToken(admin.UserName);
            return Ok(new { token });
        }

     


        private string GenerateJwtToken(string username)
        {
            var jwtSettings = _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}