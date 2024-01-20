using Blog.PLL.ViewModel.Role;
using Blog.PLL.ViewModel.User;

namespace Blog.PLL.ViewModel.UserRole
{
    public class UserRoleEditViewModel
    {
        public UserShortViewModel User{ get; set; }
        public ICollection<RoleViewModel> Roles { get; set; }
        public ICollection<RoleViewModel> AssignedRoles { get; set; }
        

    }
}
