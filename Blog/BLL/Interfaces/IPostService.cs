using Blog.BLL.Models;

namespace Blog.BLL.Interfaces
{
    public interface IPostService
    {
        public Task<PostModel> GetByUserId(long userId);

        public Task<ICollection<PostModel>> Get();

        public Task Create(PostModel model);

        public Task Update(PostModel model);

        public Task Delete(long id);
        public Task<PostModel> GetById(long id);
        
    }

}
