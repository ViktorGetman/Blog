using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.DAL;
using Blog.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.BLL.Services
{
    public class CommentService:ICommentService
    {
        private readonly IDbContextFactory<BlogDbContext> _contextFactory;
        private readonly IMapper _mapper;
        public CommentService(IDbContextFactory<BlogDbContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        public async Task<CommentModel> GetById(long id)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = await context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<CommentModel>(entity);
        }
        public async Task<ICollection<CommentModel>> Get()
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entities = await context.Comments.ToListAsync();
            return entities.Select(x => _mapper.Map<CommentModel>(x)).ToList();
        }
        public async Task Create(CommentModel model)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = _mapper.Map<CommentEntity>(model);
            await context.Comments.AddAsync(entity);
            await context.SaveChangesAsync(); 

        }
        public async Task Update(CommentModel model)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = await context.Comments.FirstOrDefaultAsync(x => x.Id == model.Id);
            entity.Content =model.Content;
            context.Comments.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task Delete(long id)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            context.Remove(new CommentEntity() {Id = id});
            await context.SaveChangesAsync();
        }
    }

}
