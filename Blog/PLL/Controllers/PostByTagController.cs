using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.PLL.ViewModel.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Blog.PLL.Controllers
{
    [Route("[controller]")]
    public class PostByTagController: Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostByTagController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;

        }
        [Route("{tag}")]
        public async Task<IActionResult> Index(string tag)
        {
            var postModels = await _postService.GetPostsByTag(tag);
            var postViewModels = postModels.Select(x => _mapper.Map<PostModel, PostShortViewModel>(x)).ToArray();
            var viewModel = new PostsByTagViewModel
            {
                TagName = tag,
                Posts = postViewModels,
           
            };

            return View(viewModel);
        }
    }
}
