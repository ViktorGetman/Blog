using Blog.Core.Enums;

namespace Blog.ViewModel.Role
{
    public class RoleViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RoleType RoleType { get; set; }
        public int UserCount { get; set; }
    }
}
