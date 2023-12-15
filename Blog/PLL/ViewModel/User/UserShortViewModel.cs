using Blog.Common.Enums;
using Blog.PLL.ViewModel.Post;

namespace Blog.PLL.ViewModel.User
{
    public class UserShortViewModel
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
    }
}
