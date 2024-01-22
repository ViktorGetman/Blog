namespace Blog.DAL.Entities
{
    public class PostEntity
    {
        public long Id { get; set; }
        public string PostName { get; set; }
        public string PostContent { get; set; }
        public long UserId { get; set; }
        public UserEntity User { get; set; }
        public ICollection<CommentEntity> Comments { get; set; }
        public ICollection<TagEntity> Tags { get; set; }

    }
}
