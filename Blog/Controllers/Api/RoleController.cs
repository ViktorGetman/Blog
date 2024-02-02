using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.Core.Enums;
using Blog.DTO.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]

    public class RoleController : Controller
    {


        private readonly IRoleService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<RoleController> _logger;

        public RoleController(IRoleService service, IMapper mapper,ILogger<RoleController> logger)
        {

            _service = service;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        [Route("")]
        [Authorize(Roles = $"{nameof(RoleType.Administrator)}")]
        public async Task<IActionResult> GetRole()
        {
            var models = await _service.Get();
            var dto = models.Select(x => _mapper.Map<RoleModel, RoleDto>(x)).ToArray();

            return StatusCode(200, dto);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = $"{nameof(RoleType.Administrator)}")]
        public async Task<IActionResult> GetRoleById(long id)
        {
            var model = await _service.GetById(id);
            var dto = _mapper.Map<RoleModel, RoleDto>(model);

            return StatusCode(200, dto);
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = $"{nameof(RoleType.Administrator)}")]
        public async Task<IActionResult> Add(AddRoleDto request)
        {
            var model = _mapper.Map<AddRoleDto, RoleModel>(request);
            await _service.Create(model);
            _logger.LogInformation("Добавлена роль пользователем (email={email})", User.Identity?.Name);
            return StatusCode(200);
        }


        [HttpPut]
        [Route("")]
        [Authorize(Roles = $"{nameof(RoleType.Administrator)}")]
        public async Task<IActionResult> Edit([FromBody] UpdateRoleDto dto)
        {

            var model = _mapper.Map<UpdateRoleDto, RoleModel>(dto);
            await _service.Update(model);
            _logger.LogInformation("Изменена роль пользователем (email={email})", User.Identity?.Name);
            return StatusCode(200);

        }


        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = $"{nameof(RoleType.Administrator)}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _service.Delete(id);
            _logger.LogInformation("Удалена роль пользователем (email={email})", User.Identity?.Name);
            return StatusCode(200);

        }

    }
}
