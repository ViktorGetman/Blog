using Blog.BLL.Models;
using Blog.DAL.Entities;
using Microsoft.EntityFrameworkCore.Internal;

namespace Blog.BLL.Interfaces
{
    public interface IUserService
    {
        public Task<UserModel> GetById(long id);

        public Task<ICollection<UserModel>> Get();

        public Task Create(CreateUserModel model);

        public Task Update(UserModel model);

        public Task Delete(long id);

        public Task UpdateUserRole(EditUserRoleModel model);
    }
}
