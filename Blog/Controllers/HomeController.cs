using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.ViewModel.Post;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{


    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public HomeController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;

        }
        public async Task<IActionResult> Index()
        {
            var postModels = await _postService.Get();
            var postViewModels = postModels.Select(x => _mapper.Map<PostModel, PostShortViewModel>(x)).ToArray();
            var postCollectionViewModel = new PostCollectionViewModel() { Posts = postViewModels };
            return View(postCollectionViewModel);
        }
    }
}
