using Blog.BLL.Models;
using Blog.Common.Enums;
using Blog.PLL.ViewModel.Post;

namespace Blog.PLL.ViewModel.User
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public ICollection<long> RoleIds { get; set; }
        public ICollection<RoleType> Roles { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }
        public ICollection<PostShortViewModel> Posts { get; set; }
    }
}
