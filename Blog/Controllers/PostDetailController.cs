﻿using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.ViewModel.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Blog.Controllers;


[Route("[controller]")]

public class PostDetailController : Controller
{
    private readonly IPostService _postService;
    private readonly IMapper _mapper;

    public PostDetailController(IPostService postService, IMapper mapper)
    {
        _postService = postService;
        _mapper = mapper;

    }
    [Route("{id}")]
    public async Task<IActionResult> Index(long id)
    {

        var postModel = await _postService.GetById(id);
        var postViewModel = _mapper.Map<PostModel, PostViewModel>(postModel);
        return View(postViewModel);
    }
    [Route("Add")]
    [Authorize]
    public IActionResult Add()
    {
        return View();
    }
    [Route("Edit/{id}")]
    [Authorize]
    public async Task<IActionResult> Edit(long id)
    {

        var postModel = await _postService.GetById(id);
        var postViewModel = _mapper.Map<PostModel, PostShortViewModel>(postModel);
        return View(postViewModel);
    }
}
