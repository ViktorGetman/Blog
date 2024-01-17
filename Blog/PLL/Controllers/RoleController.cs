using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.BLL.Services;
using Blog.PLL.ViewModel.Post;
using Blog.PLL.ViewModel.Role;
using Microsoft.AspNetCore.Mvc;

namespace Blog.PLL.Controllers
{

    [Route("[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
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
        [Route("Add")]
        public IActionResult Add()
        {
            return View();
        }
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(long id)
        {

            var roleModel = await _roleService.GetById(id);
            var roleViewModel = _mapper.Map<RoleModel, RoleViewModel>(roleModel);
            return View(roleViewModel);
        }
    }
}
