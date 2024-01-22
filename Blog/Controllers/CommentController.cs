using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.Core.Enums;
using Blog.ViewModel.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("[controller]")]

    public class CommentController : Controller
    {

        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;

        }
        [Route("")]
        [Authorize(Roles = $"{nameof(RoleType.Administrator)}, {nameof(RoleType.Moderator)}")]
        public async Task<IActionResult> Index()
        {

            var commentModels = await _commentService.Get();
            var commentViewModels = commentModels.Select(x => _mapper.Map<CommentModel, CommentViewModel>(x)).ToList();
            var commentCollectionViewModel = new CommentCollectionViewModel() { Comments = commentViewModels };
            return View(commentCollectionViewModel);
        }
        [Route("edit/{commentId}")]
        [Authorize]
        public async Task<IActionResult> Edit(long commentId)
        {

            var commentModel = await _commentService.GetById(commentId);
            var commentViewModel = _mapper.Map<CommentModel, CommentViewModel>(commentModel);
            return View(commentViewModel);
        }
        [Route("add/{postId}")]
        [Authorize]
        public IActionResult Add(long postId)
        {
            var userId = long.Parse(User.FindFirst("Id").Value);
            var viewModel = new AddCommentViewModel() { PostId = postId, UserId = userId };
            return View(viewModel);
        }
    }
}

