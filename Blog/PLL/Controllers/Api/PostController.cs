using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.PLL.DTO.Post;
using Microsoft.AspNetCore.Mvc;

namespace Blog.PLL.Controlers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : Controller
    {


        private IPostService _service;
        private IMapper _mapper;

        public PostController(IPostService service, IMapper mapper)
        {

            _service = service;
            _mapper = mapper;
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
        public async Task<IActionResult> Add(AddPostDto request)
        {
            var model = _mapper.Map<AddPostDto, PostModel>(request);
            await _service.Create(model);

            return StatusCode(200);
        }


        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Edit([FromBody] UpdatePostDto dto)
        {

            var model = _mapper.Map<UpdatePostDto, PostModel>(dto);
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

