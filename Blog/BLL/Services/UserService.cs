﻿using AutoMapper;
using Blog.BLL.Models;
using Blog.DAL.Entities;
using Blog.DAL;
using Microsoft.EntityFrameworkCore;
using Blog.BLL.Interfaces;
using System.Data;

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
                .FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<UserModel>(entity);
        }
        public async Task<ICollection<UserModel>> Get()
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entities = await context.Users.Include(x => x.Roles).ThenInclude(x=> x.Role).ToListAsync();
            return entities.Select(x => _mapper.Map<UserModel>(x)).ToList();
        }
        public async Task Create(UserModel model)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = _mapper.Map<UserEntity>(model);
            if (model.RoleIds?.Any() ?? false)
            {
                entity.Roles = new List<UserRoleEntity>();
                foreach (var roleId in model.RoleIds)
                {
                    var userRole = new UserRoleEntity()
                    {
                        RoleId = roleId,
                        User = entity
                    };
                    entity.Roles.Add(userRole);
                }
            }
            await context.Users.AddAsync(entity);
            await context.SaveChangesAsync();

        }
        public async Task Update(UserModel model)
        {
            var context = await _contextFactory.CreateDbContextAsync();
            var entity = await context.Users.Include(x => x.Roles)
                .FirstOrDefaultAsync(x => x.Id == model.Id);
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Age = model.Age;
            entity.Photo = model.Photo;

            if (model.RoleIds != null)
            {
                foreach (var role in entity.Roles)
                {
                    if (!model.RoleIds.Any(x => x == role.RoleId))
                    {
                        context.UserRoles.Remove(role);
                    }
                }
                foreach (var roleId in model.RoleIds)
                {
                    if (!entity.Roles.Any(x => x.RoleId == roleId))
                    {
                        var userRole = new UserRoleEntity()
                        {
                            RoleId = roleId,
                            User = entity
                        };
                        entity.Roles.Add(userRole);
                    }
                }
                }
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
        }
    }
