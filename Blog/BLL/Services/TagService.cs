using AutoMapper;
using Blog.BLL.Models;
using Blog.DAL.Entities;
using Blog.DAL;
using Microsoft.EntityFrameworkCore;
using Blog.BLL.Interfaces;

namespace Blog.BLL.Services
{
    public class TagService : ITagService
    {
        private readonly IDbContextFactory<BlogDbContext> _contextFactory;
        private readonly IMapper _mapper;
        public TagService(IDbContextFactory<BlogDbContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        public async Task<TagModel> GetById(long id)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = await context.Tags.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<TagModel>(entity);
        }
        public async Task<ICollection<TagModel>> Get()
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entities = await context.Tags.ToListAsync();
            return entities.Select(x => _mapper.Map<TagModel>(x)).ToList();
        }
        public async Task Create(TagModel model)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = _mapper.Map<TagEntity>(model);
            await context.Tags.AddAsync(entity);
            await context.SaveChangesAsync();

        }
        public async Task Update(TagModel model)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = await context.Tags.FirstOrDefaultAsync(x => x.Id == model.Id);
            entity.Content = model.Content;
            context.Tags.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task Delete(long id)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            context.Remove(new TagEntity() { Id = id });
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<TagStatisticModel>> GetTagStatistic()
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var models = await context.Tags.GroupBy(x => x.Content)
                .Select(x => new TagStatisticModel() { Content = x.Key, PostCount = x.Count() })
                .ToListAsync();
            return models;
        }
    }
}
