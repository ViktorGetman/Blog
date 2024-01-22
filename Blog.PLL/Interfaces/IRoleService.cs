using Blog.BLL.Models;

namespace Blog.BLL.Interfaces
{
    public interface IRoleService
    {
        public Task<RoleModel> GetById(long id);

        public Task<ICollection<RoleModel>> Get();

        public Task Create(RoleModel model);

        public Task Update(RoleModel model);

        public Task Delete(long id);
    }
}
