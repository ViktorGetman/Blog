using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.PLL.DTO.Role;
using Microsoft.AspNetCore.Mvc;

namespace Blog.PLL.Controlers
{
    [ApiController]
    [Route("[controller]")]

    public class RoleController : Controller
    {


        private IRoleService _service;
        private IMapper _mapper;

        public RoleController(IRoleService service, IMapper mapper)
        {

            _service = service;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetRole()
        {
            var models = await _service.Get();
            var dto = models.Select(x => _mapper.Map<RoleModel, RoleDto>(x)).ToArray();

            return StatusCode(200, dto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRoleById(long id)
        {
            var model = await _service.GetById(id);
            var dto = _mapper.Map<RoleModel, RoleDto>(model);

            return StatusCode(200, dto);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Add(AddRoleDto request)
        {
            var model = _mapper.Map<AddRoleDto, RoleModel>(request);
            await _service.Create(model);

            return StatusCode(200);
        }


        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Edit([FromBody] UpdateRoleDto dto)
        {

            var model = _mapper.Map<UpdateRoleDto, RoleModel>(dto);
            await _service.Update(model);
            return StatusCode(200);

        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _service.Delete(id);

            return StatusCode(200);

        }
    
    }
}
