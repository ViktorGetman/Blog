using Blog.DAL.Entities;

namespace Blog.PLL.DTO.Comment
{
    public class CommentDto
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public long PostId { get; set; }
        public long UserId { get; set; }

    }
}
