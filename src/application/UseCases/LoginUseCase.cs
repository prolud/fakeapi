using application.Dtos;
using domain.Interfaces.Repositories;
using domain.Interfaces.Services;

namespace application.UseCases
{
    public class LoginUseCase(IUserRepository _userRepository, IJwtService _jwtService)
    {
        public async Task<UseCaseResult> ExecuteAsync(string username, string password)
        {
            var user = await _userRepository.GetAsync(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                return new()
                {
                    Content = "Wrong username or password.",
                    StatusCode = System.Net.HttpStatusCode.Unauthorized
                };
            }

            return new()
            {
                Content = new JwtResult
                {
                    Token = _jwtService.GenerateJwt(),
                    Expires = DateTime.UtcNow.AddDays(1),
                }
            };
        }
    }
}