namespace Blog.PLL.ViewModel.Post
{
    internal class PostsByTagViewModel
    {
        public string TagName { get; set; }
        public ICollection<PostShortViewModel> Posts { get; set; }
    }
}