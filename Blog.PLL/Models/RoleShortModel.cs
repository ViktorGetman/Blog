using Blog.Core.Enums;

namespace Blog.BLL.Models
{
    public class RoleShortModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RoleType RoleType { get; set; }
    }
}
