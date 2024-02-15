namespace Blog.DTO.Post
{
    public class UpdatePostDto
    {
        public long Id { get; set; }
        public string PostName { get; set; }
        public string PostContent { get; set; }
        public string[] Tags { get; set; }

    }

}
