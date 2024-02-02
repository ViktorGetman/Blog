using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Blog.DTO.User;

namespace Blog.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {


        private readonly IUserService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService service, IMapper mapper, ILogger<UserController> logger)
        {

            _service = service;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetUser()
        {
            var models = await _service.Get();
            var dto = models.Select(x => _mapper.Map<UserModel, UserDto>(x)).ToArray();

            return StatusCode(200, dto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            var model = await _service.GetById(id);
            var dto = _mapper.Map<UserModel, UserDto>(model);

            return StatusCode(200, dto);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Add(AddUserDto request)
        {
            var model = _mapper.Map<AddUserDto, CreateUserModel>(request);
            await _service.Create(model);
            _logger.LogInformation("Пользователь зарегистрирован (email={email})", User.Identity?.Name);
            return StatusCode(200);
        }


        [HttpPut]
        [Route("edit")]
        [Authorize]
        public async Task<IActionResult> Edit([FromBody] UpdateUserDto dto)
        {

            var model = _mapper.Map<UpdateUserDto, UserModel>(dto);
            await _service.Update(model);
            _logger.LogInformation("Пользователь изменил свои данные (email={email})", User.Identity?.Name);
            return StatusCode(200);

        }


        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _service.Delete(id);
            if (HttpContext.User.Identity.IsAuthenticated && HttpContext.User.FindFirst("Id").Value == id.ToString())
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            _logger.LogInformation("Пользователь удален(email={email})", User.Identity?.Name);
            return StatusCode(200);

        }
    }
}
