using Blog.BLL.Models;
using Blog.Common.Enums;
using Blog.PLL.ViewModel.Post;

namespace Blog.PLL.ViewModel.User
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public ICollection<string> Roles { get; set; }

        public int CommentsCount { get; set; }
        public ICollection<PostShortViewModel> Posts { get; set; }
    }
}
