using Blog.BLL.Models;
using Blog.DAL.Entities;
using Blog.PLL.DTO.Comment;
using Blog.PLL.DTO.Post;

namespace Blog.PLL.DTO.User
{
    public class UserDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public long[] RoleIds { get; set; }
    }
}
