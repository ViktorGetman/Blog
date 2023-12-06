using Blog.BLL.Models;
using Blog.DAL.Entities;
using Microsoft.EntityFrameworkCore.Internal;

namespace Blog.BLL.Interfaces
{
    public interface ICommentService
    {
        public Task<CommentModel> GetById(long id);

        public Task<ICollection<CommentModel>> Get();

        public Task Create(CommentModel model);

        public Task Update(CommentModel model);

        public Task Delete(long id);

    }
}
