using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.PLL.ViewModel.User;
using Microsoft.AspNetCore.Mvc;

namespace Blog.PLL.Controllers
{
    public class UserCollectionController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserCollectionController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;

        }
        public async Task<IActionResult> Index()
        {
            var userModels = await _userService.Get();
            var userViewModels = userModels.Select(x => _mapper.Map<UserModel, UserShortViewModel>(x)).ToArray();
            var userCollectionViewModel = new UserCollectionViewModel() { Users = userViewModels };
            return View(userCollectionViewModel);
        }
    }
}
