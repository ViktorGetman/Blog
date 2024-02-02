using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IAuthenticationService = Blog.BLL.Interfaces.IAuthenticationService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Blog.DTO;

namespace Blog.Controllers.Api
{
    [ApiController]
    [Route("api/")]
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
            var models = await _service.Login(loginDto.Email, loginDto.Password);
            if (models == null)
            {
                _logger.LogInformation("Неудачная попытка авторизации (email={email})", loginDto.Email);
                return StatusCode(401, "Неверный логин или пароль");
            }
            var roleClaims = models.Roles.Select(x => new Claim(ClaimTypes.Role, x.RoleType.ToString()));
            var claims = new List<Claim>
            {
              new Claim(ClaimsIdentity.DefaultNameClaimType, models.Email),
              new Claim(ClaimTypes.Name, $"{models.FirstName} {models.LastName}"),
              new Claim("Id", models.Id.ToString()),
            };
            claims.AddRange(roleClaims);
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
            _logger.LogInformation("Пользователь вошел в аккаунт(email={email})", loginDto.Email);
            return StatusCode(200, "Успешная авторизация");
        }

        [HttpPost]
        [Route("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var userEmail = User.Identity?.Name;
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _logger.LogInformation("Пользователь вышел из аккаунта (email={email})", userEmail);
            return StatusCode(200, "Успешная деавторизация");
        }


    }
}
