using Blog.BLL.Models;
using Blog.DAL.Entities;
using Microsoft.EntityFrameworkCore.Internal;

namespace Blog.BLL.Interfaces
{
    public interface ITagService
    {
        public Task<TagModel> GetById(long id);

        public Task<ICollection<TagModel>> Get();

        public Task Create(TagModel model);

        public Task Update(TagModel model);

        public Task Delete(long id);

        public Task<ICollection<TagStatisticModel>> GetTagStatistic();

    }
}
