using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.DTO.Tag;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : Controller
    {


        private readonly ITagService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<TagController> _logger;

        public TagController(ITagService service, IMapper mapper, ILogger<TagController> logger)
        {

            _service = service;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetTag()
        {
            var models = await _service.Get();
            var dto = models.Select(x => _mapper.Map<TagModel, TagDto>(x)).ToArray();

            return StatusCode(200, dto);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTagById(long id)
        {
            var model = await _service.GetById(id);
            var dto = _mapper.Map<TagModel, TagDto>(model);

            return StatusCode(200, dto);
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> Add(AddTagDto request)
        {
            var model = _mapper.Map<AddTagDto, TagModel>(request);
            await _service.Create(model);
            _logger.LogInformation("Добавлен тэг пользователем (email={email})", User.Identity?.Name);
            return StatusCode(200);
        }


        [HttpPut]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> Edit([FromBody] UpdateTagDto dto)
        {

            var model = _mapper.Map<UpdateTagDto, TagModel>(dto);
            await _service.Update(model);
            _logger.LogInformation("Изменен тэг пользователем (email={email})", User.Identity?.Name);
            return StatusCode(200);

        }


        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _service.Delete(id);
            _logger.LogInformation("Удален тэг пользователем (email={email})", User.Identity?.Name);
            return StatusCode(200);

        }
    }
}
