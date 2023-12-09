using AutoMapper;
using Blog.BLL.Interfaces;
using Blog.BLL.Models;
using Blog.DAL.Entities;
using Blog.DAL;
using Microsoft.EntityFrameworkCore;

namespace Blog.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IDbContextFactory<BlogDbContext> _contextFactory;
        private readonly IMapper _mapper;
        public RoleService(IDbContextFactory<BlogDbContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        public async Task<RoleModel> GetById(long id)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = await context.Roles.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<RoleModel>(entity);
        }
        public async Task<ICollection<RoleModel>> Get()
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entities = await context.Roles.ToListAsync();
            return entities.Select(x => _mapper.Map<RoleModel>(x)).ToList();
        }
        public async Task Create(RoleModel model)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = _mapper.Map<RoleEntity>(model);
            await context.Roles.AddAsync(entity);
            await context.SaveChangesAsync();

        }
        public async Task Update(RoleModel model)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = await context.Roles.FirstOrDefaultAsync(x => x.Id == model.Id);
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.RoleType = model.RoleType;


            context.Roles.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task Delete(long id)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            context.Remove(new RoleEntity() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}