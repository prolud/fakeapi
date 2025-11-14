using api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(AuthLoginRequest loginRequest)
        {
            if (string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return Unauthorized("Usuário ou senha incorretos");
            }

            string GenerateJwt()
            {
                Random random = new();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var jwt1 = "ey" + new string([.. Enumerable.Repeat(chars, 36).Select(s => s[random.Next(s.Length)])]);
                var jwt2 = "ey" + new string([.. Enumerable.Repeat(chars, 91).Select(s => s[random.Next(s.Length)])]);
                var jwt3 = new string([.. Enumerable.Repeat(chars, 38).Select(s => s[random.Next(s.Length)])]);
                var jwt4 = new string([.. Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)])]);

                return $"{jwt1}.{jwt2}.{jwt3}-{jwt4}".ToLower();
            }

            return Ok(new
            {
                Token = GenerateJwt(),
                Expires = DateTime.UtcNow.AddDays(1),
                Type = "Bearer",
            });
        }
    }
}