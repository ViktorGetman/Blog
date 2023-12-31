﻿using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.PLL.DTO.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.PLL.Controlers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : Controller
    {


        private ICommentService _service;
        private IMapper _mapper;

        public CommentController(ICommentService service, IMapper mapper)
        {

            _service = service;
            _mapper = mapper;
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
        public async Task<IActionResult> Add(AddCommentDto request)
        {
            var model = _mapper.Map<AddCommentDto, CommentModel>(request);
            await _service.Create(model);

            return StatusCode(200);
        }


        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Edit([FromBody] UpdateCommentDto dto)
        {

            var model = _mapper.Map<UpdateCommentDto, CommentModel>(dto);
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
