namespace Blog.ViewModel.Post
{
    public class PostsByTagViewModel
    {
        public string TagName { get; set; }
        public ICollection<PostShortViewModel> Posts { get; set; }
    }
}