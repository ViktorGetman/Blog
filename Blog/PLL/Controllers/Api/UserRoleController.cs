using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.Common.Enums;
using Blog.PLL.DTO.User;
using Blog.PLL.DTO.UserRole;
using Blog.PLL.ViewModel.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.PLL.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRoleController:Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserRoleController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;

        }
        [HttpPut]
        [Route("edit")]
        [Authorize(Roles = $"{nameof(RoleType.Administrator)}")]
        public async Task<IActionResult> Edit([FromBody] EditUserRoleDto dto)
        {

            var model = _mapper.Map<EditUserRoleDto, EditUserRoleModel>(dto);
            await _userService.UpdateUserRole(model);
            return StatusCode(200);

        }
    }
}
