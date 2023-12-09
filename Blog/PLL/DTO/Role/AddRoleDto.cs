using Blog.Common.Enums;

namespace Blog.PLL.DTO.Role
{
    public class AddRoleDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public RoleType RoleType { get; set; }
    }
}
