using AutoMapper;
using Blog.BLL.Models;
using Blog.DAL.Entities;
using Blog.DAL;
using Microsoft.EntityFrameworkCore;
using Blog.BLL.Interfaces;

namespace Blog.BLL.Services
{
    public class PostService : IPostService
    {
        private readonly IDbContextFactory<BlogDbContext> _contextFactory;
        private readonly IMapper _mapper;
        public PostService(IDbContextFactory<BlogDbContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        public async Task<PostModel> GetByUserId(long userId)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = await context.Posts.Include(x => x.User)
                .Include(x => x.Comments)
                .Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.UserId == userId);
            return _mapper.Map<PostModel>(entity);
        }
        public async Task<ICollection<PostModel>> Get()
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entities = await context.Posts.Include(x => x.User)
                .Include(x => x.Comments).Include(x => x.Tags).ToListAsync();

            return entities.Select(x => _mapper.Map<PostModel>(x)).ToList();
        }
        public async Task Create(PostModel model)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = _mapper.Map<PostEntity>(model);
            await context.Posts.AddAsync(entity);
            await context.SaveChangesAsync();

        }
        public async Task Update(PostModel model)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = await context.Posts.FirstOrDefaultAsync(x => x.Id == model.Id);
            entity.PostName = model.PostName;
            entity.PostContent = model.PostContent;
            context.Posts.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task Delete(long id)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            context.Remove(new PostEntity() { Id = id });
            await context.SaveChangesAsync();
        }

        public async Task<PostModel> GetById(long id)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = await context.Posts.Include(x => x.User)
                .Include(x => x.Comments)
                .ThenInclude(x => x.User)
                .Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<PostModel>(entity);
        }
    }
}

