namespace Blog.BLL.Models
{
    public class CommentModel
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public long PostId { get; set; }
        public long UserId { get; set; }
        public UserShortModel User { get; set; }

    }
}
