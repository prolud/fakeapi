using api.Dtos;
using application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(LoginUseCase _loginUseCase) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthLoginRequest loginRequest)
        {
            var result = await _loginUseCase.ExecuteAsync(loginRequest.Username, loginRequest.Password);
            return StatusCode((int)result.StatusCode, result.Content);
        }
    }
}