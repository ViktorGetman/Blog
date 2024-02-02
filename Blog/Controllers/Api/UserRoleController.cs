using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.Core.Enums;
using Blog.DTO.UserRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRoleController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<UserRoleController> _logger;

        public UserRoleController(IUserService userService, IMapper mapper, ILogger<UserRoleController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpPut]
        [Route("edit")]
        [Authorize(Roles = $"{nameof(RoleType.Administrator)}")]
        public async Task<IActionResult> Edit([FromBody] EditUserRoleDto dto)
        {

            var model = _mapper.Map<EditUserRoleDto, EditUserRoleModel>(dto);
            await _userService.UpdateUserRole(model);
            _logger.LogInformation("Роль пользователя изменена (email={email})", User.Identity?.Name);
            return StatusCode(200);

        }
    }
}
