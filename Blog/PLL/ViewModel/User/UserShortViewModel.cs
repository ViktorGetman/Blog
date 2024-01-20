using Blog.BLL.Models;
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
        public int Age { get; set; }
        public ICollection<string> Roles { get; set; }

        public int CommentsCount { get; set; }
        public int PostsCount { get; set; }

        public static implicit operator UserShortViewModel(UserViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
