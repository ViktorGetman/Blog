using Blog.DAL.Entities;
using Blog.DTO.Comment;
using Blog.DTO.Tag;

namespace Blog.DTO.Post
{
    public class PostDto
    {
        public long Id { get; set; }
        public string PostName { get; set; }
        public string PostContent { get; set; }
        public long UserId { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
        public ICollection<TagDto> Tags { get; set; }
    }

}
