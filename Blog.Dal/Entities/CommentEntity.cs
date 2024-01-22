namespace Blog.DAL.Entities
{
    public class CommentEntity
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public long PostId { get; set; }
        public long UserId { get; set; }

        public PostEntity Post { get; set; }
        public UserEntity User { get; set; }
    }
}
