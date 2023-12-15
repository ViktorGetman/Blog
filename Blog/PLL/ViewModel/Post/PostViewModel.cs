using Blog.PLL.ViewModel.User;

namespace Blog.PLL.ViewModel.Post
{
    public class PostViewModel
    {
        public long Id { get; set; }
        public string PostName { get; set; }
        public string PostContent { get; set; }
        public UserShortViewModel User { get; set; }
        public ICollection<CommentViewModel> Comments { get; set; }
        public string[] Tags { get; set; }
    }
}
