using application.Dtos;
using domain.Interfaces.Repositories;

namespace application.UseCases
{
    public class LoginUseCase(IUserRepository _userRepository)
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
                Content = new
                {
                    Token = GenerateJwtUseCase.ExecuteAsync(),
                    Expires = DateTime.UtcNow.AddDays(1),
                    Type = "Bearer",
                }
            };
        }
    }
}