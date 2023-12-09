using Blog.DAL.Entities;

namespace Blog.BLL.Models
{
    public class RoleModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<UserModel> Users { get; set; }
    }
}
