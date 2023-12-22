using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.BLL.Services;
using Blog.PLL.ViewModel.Role;
using Microsoft.AspNetCore.Mvc;

namespace Blog.PLL.Controllers
{
    public class RoleCollectionController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleCollectionController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;

        }
        public async Task<IActionResult> Index()
        {
            var roleModels = await _roleService.Get();
            var roleViewModels = roleModels.Select(x => _mapper.Map<RoleModel, RoleViewModel>(x)).ToArray();
            var roleCollectionViewModel = new RoleCollectionViewModel() { Roles = roleViewModels };
            return View(roleCollectionViewModel);
        }
    }
}
