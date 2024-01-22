using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.ViewModel.Tag;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("[controller]")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public TagController(ITagService tagService, IMapper mapper)
        {
            _tagService = tagService;
            _mapper = mapper;

        }
        [Route("")]
        public async Task<IActionResult> Index()
        {

            var tagModels = await _tagService.GetTagStatistic();
            var tagViewModels = tagModels.Select(x => _mapper.Map<TagStatisticModel, TagViewModel>(x)).ToList();
            var tagCollectionViewModel = new TagCollctionViewModel() { Tags = tagViewModels };
            return View(tagCollectionViewModel);
        }
    }
}
