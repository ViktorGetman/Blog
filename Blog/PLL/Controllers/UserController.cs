﻿using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.PLL.ViewModel.User;
using Microsoft.AspNetCore.Mvc;

namespace Blog.PLL.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;

        }
        [Route("{id}")]
        public async Task<IActionResult> Index(long id)
        {

            var userModel = await _userService.GetById(id);
            var userViewModel = _mapper.Map<UserModel, UserViewModel>(userModel);
            return View(userViewModel);
        }
        [Route("registration")]
        public async Task<IActionResult> Registration()
        {
            return View();
        }

    }
}
