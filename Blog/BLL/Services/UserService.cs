using AutoMapper;
using Blog.BLL.Models;
using Blog.DAL.Entities;
using Blog.DAL;
using Microsoft.EntityFrameworkCore;
using Blog.BLL.Interfaces;

namespace Blog.BLL.Services
{
    public class UserService:IUserService
    {
        private readonly IDbContextFactory<BlogDbContext> _contextFactory;
        private readonly IMapper _mapper;
        public UserService(IDbContextFactory<BlogDbContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        public async Task<UserModel> GetById(long id)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<UserModel>(entity);
        }
        public async Task<ICollection<UserModel>> Get()
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entities = await context.Users.ToListAsync();
            return entities.Select(x => _mapper.Map<UserModel>(x)).ToList();
        }
        public async Task Create(UserModel model)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = _mapper.Map<UserEntity>(model);
            await context.Users.AddAsync(entity);
            await context.SaveChangesAsync();

        }
        public async Task Update(UserModel model)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = await context.Users.FirstOrDefaultAsync(x => x.Id == model.Id);
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Age = model.Age;
            entity.Photo = model.Photo;

            context.Users.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task Delete(long id)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            context.Remove(new UserEntity() { Id = id });
            await context.SaveChangesAsync();
        }
    }
}
