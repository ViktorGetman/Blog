namespace Blog.DAL.Entities
{
    public class TagEntity
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public long PostId { get; set; }
        public PostEntity Post { get; set; }
    }
}
