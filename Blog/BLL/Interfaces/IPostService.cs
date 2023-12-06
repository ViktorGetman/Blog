using Blog.BLL.Models;
using Blog.DAL.Entities;
using Microsoft.EntityFrameworkCore.Internal;

namespace Blog.BLL.Interfaces
{
    public interface IPostService
    {
        public Task<PostModel> GetByUserId(long userId);

        public Task<ICollection<PostModel>> Get();

        public Task Create(PostModel model);

        public Task Update(PostModel model);

        public Task Delete(long id);
    }

}
