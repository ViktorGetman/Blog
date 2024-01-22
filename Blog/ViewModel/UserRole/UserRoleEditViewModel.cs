using Blog.ViewModel.Role;
using Blog.ViewModel.User;

namespace Blog.ViewModel.UserRole
{
    public class UserRoleEditViewModel
    {
        public UserShortViewModel User { get; set; }
        public ICollection<RoleViewModel> Roles { get; set; }
        public ICollection<RoleViewModel> AssignedRoles { get; set; }


    }
}
