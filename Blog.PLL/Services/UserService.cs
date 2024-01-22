using AutoMapper;
using Blog.BLL.Models;
using Blog.DAL.Entities;
using Blog.DAL;
using Microsoft.EntityFrameworkCore;
using Blog.BLL.Interfaces;
using System.Data;
using Blog.Core.Enums;

namespace Blog.BLL.Services
{
    public class UserService : IUserService
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
            var entity = await context.Users.Include(x => x.Roles).ThenInclude(x => x.Role)
                .Include(x => x.Posts).ThenInclude(x => x.Tags).Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<UserModel>(entity);
        }
        public async Task<ICollection<UserModel>> Get()
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entities = await context.Users.Include(x => x.Roles).ThenInclude(x => x.Role)
                .Include(x => x.Posts).Include(x => x.Comments).ToListAsync();
            return entities.Select(x => _mapper.Map<UserModel>(x)).ToList();
        }
        public async Task Create(CreateUserModel model)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = _mapper.Map<UserEntity>(model);
            entity.Photo = "";
            var role = await context.Roles.FirstOrDefaultAsync(x => x.RoleType == RoleType.User);
            if (role == null)
            {
                throw new InvalidOperationException("В бд не найдена роль \"Пользователь\"");
            }
            entity.Roles = new List<UserRoleEntity>();
            var userRole = new UserRoleEntity()
            {
                RoleId = role.Id,
                User = entity
            };
            entity.Roles.Add(userRole);

            await context.Users.AddAsync(entity);
            await context.SaveChangesAsync();

        }
        public async Task Update(UserModel model)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = await context.Users
                .FirstOrDefaultAsync(x => x.Id == model.Id);
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
            var entity = await context.Users.Include(x => x.Roles)
               .FirstOrDefaultAsync(x => x.Id == id);
            context.Remove(entity);
            context.RemoveRange(entity.Roles);
            await context.SaveChangesAsync();
        }

        public async Task UpdateUserRole(EditUserRoleModel model)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entities = await context.UserRoles.Where(x => x.UserId == model.UserId).ToListAsync();

                foreach (var role in entities)
                {
                    if (!model.RoleIds.Any(x => x == role.RoleId))
                    {
                        context.UserRoles.Remove(role);
                    }
                }
                foreach (var roleId in model.RoleIds)
                {
                    if (!entities.Any(x => x.RoleId == roleId))
                    {
                        var userRole = new UserRoleEntity()
                        {
                            RoleId = roleId,
                            UserId = model.UserId
                        };
                        context.UserRoles.Add(userRole);
                    }
                }
            
            await context.SaveChangesAsync();
        }
    }
}
