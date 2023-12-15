using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.PLL.DTO.Tag;
using Microsoft.AspNetCore.Mvc;

namespace Blog.PLL.Controlers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : Controller
    {


        private ITagService _service;
        private IMapper _mapper;

        public TagController(ITagService service, IMapper mapper)
        {

            _service = service;
            _mapper = mapper;
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
        public async Task<IActionResult> Add(AddTagDto request)
        {
            var model = _mapper.Map<AddTagDto, TagModel>(request);
            await _service.Create(model);

            return StatusCode(200);
        }


        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Edit([FromBody] UpdateTagDto dto)
        {

            var model = _mapper.Map<UpdateTagDto, TagModel>(dto);
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
