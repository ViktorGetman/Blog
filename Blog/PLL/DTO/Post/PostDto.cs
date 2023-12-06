using Blog.DAL.Entities;
using Blog.PLL.DTO.Comment;
using Blog.PLL.DTO.Tag;

namespace Blog.PLL.DTO.Post
{
    public class PostDto
    {
        public long Id { get; set; }
        public string PostName { get; set; }
        public string PostContent { get; set; }
        public long UserId { get; set; }
        public UserEntity User { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
        public ICollection<TagDto> Tags { get; set; }
   }

}
