using Blog.PLL.ViewModel.User;

namespace Blog.PLL.ViewModel.Comment
{
    public class CommentViewModel
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public UserShortViewModel User { get; set; }
        public long PostId { get; set; }
    }
}
