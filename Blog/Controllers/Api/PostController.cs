using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.DTO.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : Controller
    {


        private readonly IPostService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<PostController> _logger;

        public PostController(IPostService service, IMapper mapper, ILogger<PostController> logger)
        {

            _service = service;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetPost()
        {
            var models = await _service.Get();
            var dto = models.Select(x => _mapper.Map<PostModel, PostDto>(x)).ToArray();

            return StatusCode(200, dto);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPostByUserId(long id)
        {
            var model = await _service.GetByUserId(id);
            var dto = _mapper.Map<PostModel, PostDto>(model);

            return StatusCode(200, dto);
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> Add(AddPostDto request)
        {
            var model = _mapper.Map<AddPostDto, PostModel>(request);
            await _service.Create(model);
            _logger.LogInformation("Добавлен пост пользователем (email={email})", User.Identity?.Name);
            return StatusCode(200);
        }


        [HttpPut]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> Edit([FromBody] UpdatePostDto dto)
        {

            var model = _mapper.Map<UpdatePostDto, PostModel>(dto);
            await _service.Update(model);
            _logger.LogInformation("Изменен пост пользователем (email={email})", User.Identity?.Name);
            return StatusCode(200);

        }


        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _service.Delete(id);
            _logger.LogInformation("Удален пост пользователем (email={email})", User.Identity?.Name);
            return StatusCode(200);

        }
    }
}

