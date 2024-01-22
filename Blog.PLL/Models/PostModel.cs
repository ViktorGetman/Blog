using Blog.DAL.Entities;

namespace Blog.BLL.Models
{
    public class PostModel
    {
        public long Id { get; set; }
        public string PostName { get; set; }
        public string PostContent { get; set; }
        public long UserId { get; set; }
        public UserModel User { get; set; }
        public ICollection<CommentModel> Comments { get; set; }
        public ICollection<TagModel> Tags { get; set; }
    }
}
