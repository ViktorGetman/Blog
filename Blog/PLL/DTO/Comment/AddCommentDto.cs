namespace Blog.PLL.DTO.Comment
{
    public class AddCommentDto
    {
        public string Content { get; set; }
        public long PostId { get; set; }
        public long UserId { get; set; }
    }
}
