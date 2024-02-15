using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.DTO.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : Controller
    {


        private readonly ICommentService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<CommentController> _logger;

        public CommentController(ICommentService service, IMapper mapper, ILogger<CommentController> logger)
        {

            _service = service;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetComment()
        {
            var models = await _service.Get();
            var dto = models.Select(x => _mapper.Map<CommentModel, CommentDto>(x)).ToArray();

            return StatusCode(200, dto);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCommentById(long id)
        {
            var model = await _service.GetById(id);
            var dto = _mapper.Map<CommentModel, CommentDto>(model);

            return StatusCode(200, dto);
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> Add(AddCommentDto request)
        {
            var model = _mapper.Map<AddCommentDto, CommentModel>(request);
            await _service.Create(model);
            _logger.LogInformation("Добавлен комментарий пользователем (email={email})", User.Identity?.Name);
            return StatusCode(200);
        }


        [HttpPut]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> Edit([FromBody] UpdateCommentDto dto)
        {

            var model = _mapper.Map<UpdateCommentDto, CommentModel>(dto);
            await _service.Update(model);
            _logger.LogInformation("Изменен комментарий пользователем (email={email})", User.Identity?.Name);
            return StatusCode(200);

        }


        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _service.Delete(id);
            _logger.LogInformation("Удален комментарий пользователем (email={email})", User.Identity?.Name);
            return StatusCode(200);

        }
    }
}
