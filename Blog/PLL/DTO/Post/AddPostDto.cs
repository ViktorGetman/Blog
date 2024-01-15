namespace Blog.PLL.DTO.Post
{
    public class AddPostDto
    {
       
        public string PostName { get; set; }
        public string PostContent { get; set; }
        public string[]Tags { get; set; }   
        public long UserId { get; set; }

    }


}
