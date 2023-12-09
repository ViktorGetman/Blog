using Blog.DAL.Entities;

namespace Blog.BLL.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public long RoleId { get; set; }
        public RoleModel Role { get; set; }
        public ICollection<CommentModel> Comments { get; set; }
        public ICollection<PostModel> Posts { get; set; }


    }
}
