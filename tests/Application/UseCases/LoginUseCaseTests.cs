using System.Linq.Expressions;
using System.Net;
using application.UseCases;
using domain.Interfaces.Repositories;
using domain.Interfaces.Services;
using domain.Models;
using Moq;
using tests._builders;

namespace tests.Application.UseCases
{
    public class LoginUseCaseTests
    {
        private readonly Mock<IUserRepository> _userRepository = new();
        private readonly Mock<IJwtService> _jwtService = new();
        private readonly LoginUseCase _useCase;

        public LoginUseCaseTests()
        {
            _useCase = new LoginUseCase(_userRepository.Object, _jwtService.Object);
        }

        [Fact]
        public async Task ExecuteAsync_ShouldReturnToken_WhenUserExist()
        {
            _userRepository
                .Setup(s => s.GetAsync(It.IsAny<Expression<Func<DbUser, bool>>>()))
                .ReturnsAsync(new DbUserBuilder().Build());
            _jwtService
                .Setup(s => s.GenerateJwt())
                .Returns("jwt token");

            var result = await _useCase.ExecuteAsync("login", "password");

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.NotNull(result.Content); // teste
        }

        [Fact]
        public async Task ExecuteAsync_ShouldReturnUnauthorized_WhenUserDoesntExist()
        {
            _userRepository
                .Setup(s => s.GetAsync(It.IsAny<Expression<Func<DbUser, bool>>>()))
                .ReturnsAsync((DbUser?)null);

            var result = await _useCase.ExecuteAsync("login", "password");

            Assert.Equal(HttpStatusCode.Unauthorized, result.StatusCode);
            Assert.Equal("Wrong username or password.", result.Content);
        }
    }
}