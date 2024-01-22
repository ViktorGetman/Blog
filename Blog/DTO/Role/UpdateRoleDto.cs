using Blog.Core.Enums;

namespace Blog.DTO.Role
{
    public class UpdateRoleDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RoleType RoleType { get; set; }
    }
}
