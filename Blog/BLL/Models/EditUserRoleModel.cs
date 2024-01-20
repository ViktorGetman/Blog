namespace Blog.BLL.Models
{
    public class EditUserRoleModel
    {
        public long UserId { get; set; }
        public long[] RoleIds { get; set; }
    }
}
