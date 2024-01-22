namespace Blog.ViewModel.User
{
    public class UserShortViewModel
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public int Age { get; set; }
        public ICollection<string> Roles { get; set; }

        public int CommentsCount { get; set; }
        public int PostsCount { get; set; }
    }
}
