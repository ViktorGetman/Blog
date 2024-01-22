using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.Core.Enums;
using Blog.ViewModel.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
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
        [Authorize(Roles = $"{nameof(RoleType.Administrator)}")]
        public async Task<IActionResult> Index()
        {
            var roleModels = await _roleService.Get();
            var roleViewModels = roleModels.Select(x => _mapper.Map<RoleModel, RoleViewModel>(x)).ToArray();
            var roleCollectionViewModel = new RoleCollectionViewModel() { Roles = roleViewModels };
            return View(roleCollectionViewModel);
        }
        [Route("Add")]
        [Authorize(Roles = $"{nameof(RoleType.Administrator)}")]
        public IActionResult Add()
        {
            return View();
        }
        [Route("Edit/{id}")]
        [Authorize(Roles = $"{nameof(RoleType.Administrator)}")]
        public async Task<IActionResult> Edit(long id)
        {

            var roleModel = await _roleService.GetById(id);
            var roleViewModel = _mapper.Map<RoleModel, RoleViewModel>(roleModel);
            return View(roleViewModel);
        }
    }
}
