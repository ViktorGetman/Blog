using Blog.DAL.Entities;

namespace Blog.DTO.Tag
{
    public class TagDto
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public long PostId { get; set; }
    }
}
