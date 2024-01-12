using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.PLL.DTO.User;
using Microsoft.AspNetCore.Mvc;

namespace Blog.PLL.Controlers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {


        private IUserService _service;
        private IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {

            _service = service;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetUser()
        {
            var models = await _service.Get();
            var dto = models.Select(x => _mapper.Map<UserModel, UserDto>(x)).ToArray();

            return StatusCode(200, dto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            var model = await _service.GetById(id);
            var dto = _mapper.Map<UserModel, UserDto>(model);

            return StatusCode(200, dto);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Add(AddUserDto request)
        {
            var model = _mapper.Map<AddUserDto, CreateUserModel>(request);
            await _service.Create(model);

            return StatusCode(200);
        }


        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] UpdateUserDto dto)
        {

            var model = _mapper.Map<UpdateUserDto, UserModel>(dto);
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
