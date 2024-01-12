using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.PLL.ViewModel.Comment;
using Microsoft.AspNetCore.Mvc;

namespace Blog.PLL.Controllers
{
    [Route("[controller]")]

    public class CommentController:Controller
    {
           
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;

        }
        [Route("")]
        public async Task<IActionResult> Index()
        {

            var commentModels = await _commentService.Get();
            var commentViewModels = commentModels.Select(x => _mapper.Map<CommentModel, CommentViewModel>(x)).ToList();
            var commentCollectionViewModel = new CommentCollectionViewModel() { Comments = commentViewModels };
            return View(commentCollectionViewModel);
        }
        [Route("edit/{commentId}")]
        public async Task<IActionResult> Edit(long commentId)
        {

            var commentModel = await _commentService.GetById(commentId);
            var commentViewModel = _mapper.Map<CommentModel, CommentViewModel>(commentModel);
            return View(commentViewModel);
        }
        [Route("add/{postId}")]
        public IActionResult Add(long postId)
        {
            var userId = long.Parse(User.FindFirst("Id").Value);
            var viewModel = new AddCommentViewModel() { PostId = postId, UserId = userId }; 
            return View(viewModel);
        }
    }
}

