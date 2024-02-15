using System.IdentityModel.Tokens.Jwt;
using Blog.DTO;
using Microsoft.AspNetCore.Mvc;
using IAuthenticationService = Blog.Infrastructure.JwtAuthentication.IAuthenticationService;

namespace Blog.API.Controllers
{
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _service;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IAuthenticationService service, ILogger<AuthenticationController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            (JwtSecurityToken? token, bool isSuccess) = await _service.TryLogin(loginDto.Email, loginDto.Password);
            if (!isSuccess)
            {
                _logger.LogInformation("Неудачная попытка авторизации (email={email})", loginDto.Email);
                return StatusCode(401, "Неверный логин или пароль");
            }
            _logger.LogInformation("Пользователь вошел в аккаунт(email={email})", loginDto.Email);
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}