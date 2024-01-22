using Blog.BLL.Models;
using Blog.DAL.Entities;

namespace Blog.ViewModel.Post
{
    public class PostShortViewModel
    {
        public long Id { get; set; }
        public string PostName { get; set; }
        public string PostContent { get; set; }
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public string UserEmail { get; set; }
        public int CommentsCount { get; set; }
        public string[] Tags { get; set; }
    }
}
