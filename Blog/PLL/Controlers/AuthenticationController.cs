using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.PLL.DTO;
using Blog.PLL.DTO.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using IAuthenticationService = Blog.BLL.Interfaces.IAuthenticationService;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Blog.PLL.Controlers
{
    [ApiController]
    [Route("")]
    public class AuthenticationController : Controller
    {
        private IMapper _mapper;
        private IAuthenticationService _service;

        public AuthenticationController(IAuthenticationService service, IMapper mapper)
        {

            _service = service;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var models = await _service.Login(loginDto.Email, loginDto.Password);
            if (models == null)
            {
                return StatusCode(401, "Неверный логин или пароль");
            }
            var roleClaims = models.Roles.Select(x => new Claim(ClaimTypes.Role, x.ToString()));
            var claims = new List<Claim>
            {
             new Claim(ClaimsIdentity.DefaultNameClaimType, models.Email),
            };
            claims.AddRange(roleClaims);
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
            return StatusCode(200, "Успешная авторизация");
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        { 
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return StatusCode(200, "Успешная деавторизация");
        }


    }
}
