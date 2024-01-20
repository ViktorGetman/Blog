﻿using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.Common.Enums;
using Blog.PLL.ViewModel.Role;
using Blog.PLL.ViewModel.User;
using Blog.PLL.ViewModel.UserRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.PLL.Controllers
{

    [Route("[controller]")]
    public class UserRoleController : Controller
    {


        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;

        public UserRoleController(IUserService userService, IMapper mapper, IRoleService roleService)
        {
            _userService = userService;
            _mapper = mapper;
            _roleService = roleService;

        }
        [Route("Edit/{id}")]
        [Authorize(Roles = $"{nameof(RoleType.Administrator)}")]
        public async Task<IActionResult> Edit(long id)
        {
            var roleModels = await _roleService.Get();
            var roleViewModels = _mapper.Map<ICollection<RoleModel>, RoleViewModel[]>(roleModels);
            var userModel = await _userService.GetById(id);
            var userViewModel = _mapper.Map<UserModel, UserShortViewModel>(userModel);
            var assignetRoleViewModels = _mapper.Map<ICollection<RoleShortModel>, RoleViewModel[]>(userModel.Roles);
            var userRoleEditViewModel = new UserRoleEditViewModel() 
            {
                AssignedRoles = assignetRoleViewModels, 
                User = userViewModel,
                Roles =roleViewModels

            };
            return View(userRoleEditViewModel);
        }
    }
}
