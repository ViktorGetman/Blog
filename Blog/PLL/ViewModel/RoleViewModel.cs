using Blog.Common.Enums;

namespace Blog.PLL.ViewModel
{
    public class RoleViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RoleType RoleType { get; set; }
    }
}
